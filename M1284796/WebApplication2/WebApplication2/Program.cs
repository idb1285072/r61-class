using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using WebApplication2.DTOs;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDBContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("con")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/api/stu", async ([FromServices] AppDBContext db) =>
{
    return await db.Students.Include(s => s.Addresses).ToListAsync();
   
})
.WithName("GetStudents")
.WithOpenApi().Produces<Student[]>(StatusCodes.Status200OK);


app.MapDelete("/api/stu/{id}", async ([FromRoute] int id,[FromServices] AppDBContext db) =>
{
    var stu= await db.Students.Include(s => s.Addresses).FirstOrDefaultAsync(s=>s.Id==id);
    db.Students.Remove(stu);
    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithOpenApi().Produces(StatusCodes.Status204NoContent);


app.MapPost("/api/stu", async ([FromBody] StudentDto studentDto, [FromServices] AppDBContext db) =>
{

    var imageUrl = string.IsNullOrEmpty(studentDto.BaseImage64) ? null : studentDto.BaseImage64;
    var addresses = string.IsNullOrWhiteSpace(studentDto.AddressJson) ? new List<AddressDto>():JsonSerializer.Deserialize<List<AddressDto>>(studentDto.AddressJson);

    var newStudent = new Student
    {

        Name = studentDto.Name,
        AdmissionDate = studentDto.AdmissionDate,
        IsActive = studentDto.IsActive,
        ImageUrl = imageUrl
    };
    db.Students.Add(newStudent);
    await db.SaveChangesAsync();

    if (addresses.Any())
    {
        db.Addresses.AddRange(addresses.Select(a=>new Address
        { 
        
        StudentId=newStudent.Id,
        City = a.City,
        Street = a.Street,
        
        }));
        await db.SaveChangesAsync();
    }
    return Results.Created($"/api/student/{newStudent.Id}",newStudent);
}).WithOpenApi().Produces<Student>(StatusCodes.Status201Created);


//app.MapGet("/api/stu/{id}", async ([FromRoute] int id, [FromServices] AppDBContext db) =>
//{
//    var stu = await db.Students.Include(s => s.Addresses).FirstOrDefaultAsync(s => s.Id == id);
//    return stu is null ? Results.NotFound() : Results.Ok(stu);
//})
//.WithName("GetStudent")
//.WithOpenApi().Produces<Student>(StatusCodes.Status200OK);


//app.MapPut("/api/stu/{id}", async ([FromRoute] int id, [FromBody] StudentDto studentDto, [FromServices] AppDBContext db) =>
//{
//    var imageUrl = string.IsNullOrEmpty(studentDto.BaseImage64) ? null : studentDto.BaseImage64;
//    var addresses = string.IsNullOrWhiteSpace(studentDto.AddressJson) ? new List<Address>() : JsonSerializer.Deserialize<List<Address>>(studentDto.AddressJson);


//    var exStu = await db.Students.Include(s => s.Addresses).FirstOrDefaultAsync(s => s.Id == id);
//    exStu.Name = studentDto.Name;
//    exStu.AdmissionDate = studentDto.AdmissionDate;
//    exStu.IsActive = studentDto.IsActive;
//    exStu.ImageUrl = imageUrl;

//    foreach (var address in addresses)
//    {
//        if (address.Id!=0)
//        {
//            var exAdd =exStu.Addresses.FirstOrDefault(s => s.Id ==address.Id);
//            if (exAdd !=null)
//            {
//                exAdd.City = address.City;
//                exAdd.Street = address.Street;

//            }

//        }
//        else
//        {
//            db.Addresses.Add(new Address {

//                StudentId = exStu.Id,
//                City = address.City,
//                Street = address.Street,
//            });
//        }

//    }
//   await db.SaveChangesAsync();
//    return Results.NoContent();

//})
//.WithName("GetStudent")
//.WithOpenApi().Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/stu/{id}", async ([FromRoute] int id, [FromServices] AppDBContext db) =>
{
    var student = await db.Students.Include(sc => sc.Addresses).FirstOrDefaultAsync(x => x.Id == id);
    return student is null ? Results.NotFound() : Results.Ok(student);
}).WithName("GetStudent").Produces<Student>(StatusCodes.Status200OK);



app.MapPut("/api/stu/{id}", async ([FromRoute] int id, [FromBody] StudentDto studentDto, [FromServices] AppDBContext db) =>
{
    try
    {
        var existingstudent = await db.Students.Include(s => s.Addresses).FirstOrDefaultAsync(s => s.Id == id);
        if (existingstudent == null) { return Results.NotFound(); }
        existingstudent.Id = id;
        existingstudent.Name = studentDto.Name;
        existingstudent.AdmissionDate = studentDto.AdmissionDate;
        existingstudent.IsActive = studentDto.IsActive;
        if (!string.IsNullOrEmpty(studentDto.BaseImage64))
        {
            existingstudent.ImageUrl = studentDto.BaseImage64;
        }
        List<Address> addresses = new List<Address>();
        if (!string.IsNullOrWhiteSpace(studentDto.AddressJson))
        {
            addresses = JsonSerializer.Deserialize<List<Address>>(studentDto.AddressJson);
        }
        var addressIds = addresses.Select(a => a.Id).ToList();
        foreach (var address in addresses)
        {
            if (address.Id != 0)
            {
                var existingAddress = existingstudent.Addresses.FirstOrDefault(a => a.Id == address.Id);
                if (existingAddress != null)
                {
                    existingAddress.City = address.City;
                    existingAddress.Street = address.Street;
                }
            }
            else
            {
                var newAddress = new Address
                {
                    Street = address.Street,
                    City = address.City,
                    StudentId = existingstudent.Id,
                };
                db.Addresses.Add(newAddress);
            }
        }
        var addresToDelete = existingstudent.Addresses.Where(a => !addressIds.Contains(a.Id)).ToList();
        db.RemoveRange(addresToDelete);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
}).WithOpenApi()
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status500InternalServerError);



app.Run();

