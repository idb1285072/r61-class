using employeeproj.DTO;
using employeeproj.Models;
using employeeproj.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace employeeproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Modelcontext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeesController(Modelcontext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

       
        [HttpGet]
        [Route("Getemployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees
                .Include(e => e.Details)
                .ThenInclude(d => d.EmployeeTask)
                .ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Details)
                .ThenInclude(d => d.EmployeeTask)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromForm] EmployeeDTO employeeDTO)
        {
            var employeeData = JsonSerializer.Deserialize<EmployeeVM>(employeeDTO.EmployeeInfo);

            if (employeeData == null) return BadRequest("Invalid Employee Data");

            var employee = new Employee
            {
                EmployeeName = employeeData.EmployeeName,
                Birthdate = employeeData.BirthDate,
                PhoneNo = employeeData.PhoneNo,
                MaritalStatus = employeeData.MaritalStatus,
                
                
            };

            try
            {
                
                if (employeeDTO.PictureFile != null)
                {
                    var webroot = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
                    var imagesPath = Path.Combine(webroot, "Images");

                    if (!Directory.Exists(imagesPath))
                        Directory.CreateDirectory(imagesPath);

                    var fileName = Guid.NewGuid() + Path.GetExtension(employeeDTO.PictureFile.FileName);
                    var filePath = Path.Combine(imagesPath, fileName);

                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    await employeeDTO.PictureFile.CopyToAsync(fileStream);

                    employee.Picture = fileName;
                  
                }

                
                //_context.Employees.Add(employee);
                //await _context.SaveChangesAsync();


                foreach (var task in employeeData.EmployeeTasks)
                {
                    var detail = new Details
                    {
                        EmployeeId = employee.Id,
                        EmployeeTaskId = task.EmployeeTaskId,

                        AssignDate = task.AssignDate,
                        SubmitDate = task.SubmitDate,
                        ActualSubmitDate = task.ActualSubmitDate,
                        Status = task.Status,
                        Notes = task.Notes,
                    };
                    employee.Details.Add(detail);
                    //_context.Details.Add(detail);
                }
                _context.Employees.Add(employee);
               if( await _context.SaveChangesAsync()>0)
                {
                    return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
                }

                return Problem("Failed");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeDTO employeeDTO)
        {
            var employeeData = JsonSerializer.Deserialize<EmployeeVM>(employeeDTO.EmployeeInfo);

            if (employeeData == null || employeeData.Id == 0)
                return BadRequest("Invalid employee data.");

            var employee = await _context.Employees.FindAsync(employeeData.Id);
            if (employee == null)
                return NotFound("Employee not found.");

            employee.EmployeeName = employeeData.EmployeeName;
            employee.Birthdate = employeeData.BirthDate;
            employee.PhoneNo = employeeData.PhoneNo;
            employee.MaritalStatus = employeeData.MaritalStatus;

            
            if (employeeDTO.PictureFile != null)
            {
                var webroot = _env.WebRootPath;
                var imagesPath = Path.Combine(webroot, "Images");
                if (!Directory.Exists(imagesPath))
                    Directory.CreateDirectory(imagesPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(employeeDTO.PictureFile.FileName);
                var filePath = Path.Combine(imagesPath, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                await employeeDTO.PictureFile.CopyToAsync(fileStream);

                employee.Picture = fileName;
            }

           
            var existingDetails = await _context.Details
                .Where(d => d.EmployeeId == employee.Id)
                .ToListAsync();

            if (existingDetails.Any())
                _context.Details.RemoveRange(existingDetails);

            
            foreach (var task in employeeData.EmployeeTasks)
            {
                var detail = new Details
                {
                    EmployeeId = employee.Id,
                    EmployeeTaskId = task.Id,
                    AssignDate = task.AssignDate,
                    SubmitDate = task.SubmitDate,
                    ActualSubmitDate = task.ActualSubmitDate,
                    Status = task.Status,
                    Notes = task.Notes,
                };
                _context.Details.Add(detail);
            }

            await _context.SaveChangesAsync();
            return Ok("Employee updated successfully.");
        }


       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Details)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Details.RemoveRange(employee.Details);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
