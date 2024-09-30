using Hope.DomainEntites.DbEntites;
using Hope.Repositories.IRepository;
using Hope.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hope.API.Controllers.Section
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionTableRepository _sectionTableRepository;
        private readonly IStudentsTableRepository _studentsTableRepository;

        public SectionsController(ISectionTableRepository sectionTableRepository, IStudentsTableRepository studentsTableRepository)
        {
            _sectionTableRepository = sectionTableRepository ?? throw new ArgumentNullException(nameof(sectionTableRepository));
            _studentsTableRepository = studentsTableRepository;
        }




        [HttpPost]
        public IActionResult AddNewSection(String SectionName, int SectionTeacher)
        {
            SectionTable obj = new SectionTable();

            obj.SectionName = SectionName;
            obj.SectionTeacher = SectionTeacher;

            _sectionTableRepository.Add(obj);
            return Ok(obj);
        }

        [HttpGet]
        public IActionResult GetAllSections()
        {
            try
            {
                var result = _sectionTableRepository.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteSection(int sectionId)
        {
            // Check if the repository is initialized
            if (_sectionTableRepository == null)
            {
                return StatusCode(500, "Repository is not initialized.");
            }

            // Retrieve the section by ID
            var result = _sectionTableRepository.GetById(sectionId);

            // Check if the section exists
            if (result == null)
            {
                return NotFound("Section not found. Failed to delete.");
            }

            // Check if there are no students linked to the section
            if (_studentsTableRepository.Find(x => x.SectionId == sectionId).Count() == 0)
            {
                _sectionTableRepository.Delete(result);
                return Ok("Section was deleted.");
            }
            else
            {
                return BadRequest("Cannot delete section. There are students linked to it.");
            }
        }

        [HttpPut]
        public IActionResult UpdateSection(int sectionId,int SectionTeacher,String SectionName,int Isfull)
        {
         
            // Retrieve the section by ID
            var result = _sectionTableRepository.GetById(sectionId);

            // Check if the section exists
            if (result != null)
            {
                result.SectionId = sectionId;
                result.SectionName = SectionName;
                result.SectionTeacher = SectionTeacher;
                result.SectionIsFull= Isfull;

                _sectionTableRepository.Update(result);
                return Ok(result);
            }
            else
            {
                return BadRequest("Cannot Update section");
            }
        }









    }
}
