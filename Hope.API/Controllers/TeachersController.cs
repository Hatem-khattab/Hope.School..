using Hope.DomainEntites.DbEntites;
using Hope.Repositories.IRepository;
using Hope.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hope.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeachersController : ControllerBase
    {
       
        private readonly ITeachersTableRepository _TeachertablesRepository;


        public TeachersController(ITeachersTableRepository teachersTableRepository)
        {
            _TeachertablesRepository = teachersTableRepository;
        }

        [HttpPost]
        //TeachersTable newteacher
        public IActionResult AddNewTeacher(TeachersTable newteacher)
        {
            
            TeachersTable obj = new TeachersTable();

            
            
               obj.TeachersFirstName = newteacher.TeachersFirstName;
               obj.TeachersPhoneNumber = newteacher.TeachersPhoneNumber;
               obj.TeachersDateOfBirth = newteacher.TeachersDateOfBirth;
               obj.TeachersHireDate = newteacher.TeachersHireDate;
               obj.TeachersPictureUrl = newteacher.TeachersPictureUrl;
               obj.TeachersAddress = newteacher.TeachersAddress;
               obj.TeachersEmail = newteacher.TeachersEmail;
               obj.TeachersSpecialization = newteacher.TeachersSpecialization;
            


            _TeachertablesRepository.Add(obj);


            return Ok(obj);
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            try
            {
                var result = _TeachertablesRepository.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult DeleteTeacher(int Teacherid)
        {
            // Check if the repository is initialized
            if (_TeachertablesRepository == null)
            {
                return StatusCode(500, "Repository is not initialized.");
            }

            // Retrieve the section by ID
            var result = _TeachertablesRepository.GetById(Teacherid);

            // Check if the section exists
            if (result == null)
            {
                return NotFound("Section not found. Failed to delete.");
            }

            // Check if there are no students linked to the section
            if (_TeachertablesRepository.Find(x => x.TeachersId == Teacherid).Count() == 0)
            {
                _TeachertablesRepository.Delete(result);
                return Ok("Section was deleted.");
            }
            else
            {
                return BadRequest("Cannot delete section. There are students linked to it.");
            }
        }
        [HttpPut]
        public IActionResult UpdateSection(int sectionId,TeachersTable teachersTablew)
        {

            // Retrieve the section by ID
            var result = _TeachertablesRepository.GetById(sectionId);

            // Check if the section exists
            if (result != null)
            {
                result.TeachersId = sectionId;
                result.TeachersFirstName = teachersTablew.TeachersFirstName;
                result.TeachersPhoneNumber = teachersTablew.TeachersPhoneNumber;
                result.TeachersDateOfBirth = teachersTablew.TeachersDateOfBirth;
                result.TeachersHireDate = teachersTablew.TeachersHireDate;
                result.TeachersPictureUrl = teachersTablew.TeachersPictureUrl;
                result.TeachersEmail = teachersTablew.TeachersEmail;
                result.TeachersSpecialization = teachersTablew.TeachersSpecialization;
                result.TeachersAddress = teachersTablew.TeachersAddress;
                


                _TeachertablesRepository.Update(result);
                return Ok(result);
            }
            else
            {
                return BadRequest("Cannot Update section");
            }
        }



    }
}
