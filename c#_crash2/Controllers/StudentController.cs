using Microsoft.AspNetCore.Mvc;

namespace c__crash2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class StudentController : ControllerBase
    {
        private readonly StudentServiceInterface _studentService;
        public StudentController(StudentServiceInterface studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/allStudents")]

        public async Task<ActionResult<ServiceResponseStudent<List<GetStudentDto>>>> Get()
        {
            return await _studentService.GetStudentDetails();
        }

        [HttpPost("/addStudent")]
        public async Task<ActionResult<ServiceResponseStudent<List<GetStudentDto>>>> Post(AddStudentDto Student)
        {
            return await _studentService.AddStudentDetailsAsync(Student);
        }
        [HttpGet("/oneStudent")]
        public async Task<ServiceResponseStudent<GetStudentDto>> Post(int StudentId)
        {
            return await _studentService.GetStudentById(StudentId);
        }
        [HttpPut("/editStudent")]
        public async Task<ServiceResponseStudent<List<GetStudentDto>>> EditAStudent(int StudenId)
        {
          return await _studentService.EditAStudent(StudenId);

        }
        [HttpDelete("/deleteStudent")]
        public async Task<ServiceResponseStudent<List<GetStudentDto>>> DeleteAStudetn(int StudenId)
        {
            return await _studentService.DeleteAStudetn(StudenId);
        }

    }
}
