using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project_CORE.Infrastructure.Base;
using Final_Project_CORE.Utility;
using System.Diagnostics.Metrics;
using Final_Project_CORE.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Final_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("inv")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        Modelmessage Modelmessage;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            Modelmessage = new Modelmessage();
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> all = new List<Category>();
            try
            {
                all = await _unitOfWork.CateRepo.GetAll();
            }
            catch (Exception ex)
            {
                all = new List<Category>();
            }
            return all;
        }
        [HttpPost("AddRange")]
        public async Task<IActionResult> PostCategory(List<Category> Category)
        {
            try
            {
               
                _unitOfWork.CateRepo.Add(Category);
                Modelmessage = _unitOfWork.Save();
                if (Modelmessage.IsSuccess)
                {
                    return Ok(new { data = Category, result = Modelmessage });
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Category Category)
        {
            try
            {
            var isExist = await _unitOfWork.CateRepo.GetAll(c => c.Name.ToLower().Equals(Category.Name.ToLower()), null);
            if (isExist.Any())
            {
                return Problem($"{Category.Name} already exist");
            }
            _unitOfWork.CateRepo.Add(Category);
                Modelmessage = _unitOfWork.Save();
            if (Modelmessage.IsSuccess)
            {
                return Ok(new { data = Category, result = Modelmessage });
            }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Problem(Modelmessage.Message);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.CateRepo.GetById(id);
        }
        [HttpPut]
        public void PutCategory(Category Category)
        {
            _unitOfWork.CateRepo.Update(Category);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async void Delete(int id)
        {
            _unitOfWork.CateRepo.DeletebyID(x => x.Id == id);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteByEntity")]
        public void Delete(Category Category)
        {
            _unitOfWork.CateRepo.Delete(Category);
            _unitOfWork.Save();
        }
        [HttpDelete]
        [Route("DeleteRange")]
        public void DeleteRange(IEnumerable<Category> countries)
        {
            _unitOfWork.CateRepo.DeleteRange(countries);
            _unitOfWork.Save();
        }

    }
}
