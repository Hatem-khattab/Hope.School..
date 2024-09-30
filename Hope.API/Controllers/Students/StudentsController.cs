using Hope.DomainEntites.DbEntites;
using Hope.Repositories.IRepository;
using Hope.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace Hope.API.Controllers.Student
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class StudentsController : ControllerBase
    {
        private readonly IStudentsTableRepository _studentsTableRepository;
        



        public StudentsController(IStudentsTableRepository studentsTableRepository)
        {
            _studentsTableRepository = studentsTableRepository;
           
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var result = _studentsTableRepository.GetAll().ToList();
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddNewStudent(String Student)
        {
            StudentsTable obj  = new StudentsTable();
            obj.StudentsFirstName = Student;
            obj.StudentsLasttName = Student;
            
            

            _studentsTableRepository.Add(obj);


            return Ok();



        }

        [HttpDelete]
        public IActionResult DeleteStudent(int Studentid)
        {
            // Check if the repository is initialized
            if (_studentsTableRepository == null)
            {
                return StatusCode(500, "Repository is not initialized.");
            }

            // Retrieve the section by ID
            var result = _studentsTableRepository.GetById(Studentid);

            // Check if the section exists
            if (result == null)
            {
                return NotFound("Section not found. Failed to delete.");
            }

            // Check if there are no students linked to the section
            if (_studentsTableRepository.Find(x => x.StudentId == Studentid).Count() == 0)
            {
                _studentsTableRepository.Delete(result);
                return Ok("Section was deleted.");
            }
            else
            {
                return BadRequest("Cannot delete section. There are students linked to it.");
            }
        }
        [HttpPut]
        public IActionResult UpdateStudent(int Stdid,StudentsTable studentsTablew)
        {

            // Retrieve the section by ID
            var result = _studentsTableRepository.GetById(Stdid);

            // Check if the section exists
            if (result != null)
            {

                result.StudentId = studentsTablew.StudentId;
                result.StudentsEmail  = studentsTablew.StudentsEmail;
                result.StudentsFirstName = studentsTablew.StudentsFirstName;
                result.StudentsPhoneNumber = studentsTablew.StudentsPhoneNumber;
                result.StudentDateOfbirth = studentsTablew.StudentDateOfbirth;
                result.StudentsPictureUrl = studentsTablew.StudentsPictureUrl;
                result.FathersEducation = studentsTablew.FathersEducation;
                result.HighSchoolGrade = studentsTablew.HighSchoolGrade;
                result.StudentsLasttName = studentsTablew.StudentsLasttName;
                result.MothersEducation = studentsTablew.MothersEducation;
                result.StudentsAddress = studentsTablew.StudentsAddress;
                result.StudentsEnrollmentDate = studentsTablew.StudentsEnrollmentDate;
                


                _studentsTableRepository.Update(result);
                return Ok(result);
            }
            else
            {
                return BadRequest("Cannot Update section");
            }
        }





    }
}
