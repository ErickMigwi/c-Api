
using c__crash2.Models.StudentModel;

namespace c__crash2.Services.StudentServices
{
    public class StudentService : StudentServiceInterface
    {
        private static List<STUDENT> Students = new List<STUDENT>
        {
            new STUDENT(),
            new STUDENT
            {
               FirstName="Sharon",
               LastName = "Wambi",
               Course = "Business",
               Grade = 'A',
               Year = 3,
               Id = 2,
               ParentFullName= "Magret Nyokabi",
               Allergies= "none"
               
            },
             new STUDENT
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Course = "Computer Science",
                Year = 3,
                Grade = 'A', 
               ParentFullName= "Magret Nyokabi",
               Allergies= "none"
            },
            new STUDENT
            {
                Id = 2,
                FirstName = "Sharon",
                LastName = "Wambi",
                Course = "Business",
                Year = 3,
                Grade = 'A',
                 ParentFullName= "Magret Nyokabi",
               Allergies= "none"
            },
            new STUDENT
            {
                Id = 3,
                FirstName = "Sophia",
                LastName = "Martinez",
                Course = "Art",
                Year = 2,
                Grade = 'B',
                ParentFullName= "Magret Nyokabi",
                Allergies= "none"
            }

        };
        private static AddStudentDto newStudent = new AddStudentDto
        {

            Id = 10,
            FirstName = "Sophia",
            LastName = "Martinez",
            Course = "Art",
            Year = 2,
            Grade = 'B',
            ParentFullName = "Jack Martinez",
            Allergies = "Gluten"
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponseStudent<List<GetStudentDto>>> AddStudentDetailsAsync(AddStudentDto student)
        {
            var serviceResponse = new ServiceResponseStudent<List<GetStudentDto>>();
            try
            {

               

                var newStudent = _mapper.Map<STUDENT>(student);

                await _context.Students.AddAsync(newStudent);

                await _context.SaveChangesAsync();

                var data = await _context.Students.ToListAsync();

                var Data = data.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();

                serviceResponse.Data = Data;
                serviceResponse.Message = "Student added successfully";
            }
            catch (Exception ex) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error:{ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponseStudent<GetStudentDto>> GetStudentById(int StudenId)
        {
            var student = Students.FirstOrDefault(s => s.Id == StudenId);
            var serviceResponse = new ServiceResponseStudent<GetStudentDto>();
          
           if(student != null)
            {
                serviceResponse.Data = _mapper.Map<GetStudentDto>(student);
                return serviceResponse;
            }
            else
            {
                serviceResponse.Message = "Student could not be found";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponseStudent<List<GetStudentDto>>> GetStudentDetails()
        {
            var serviceResponse = new ServiceResponseStudent<List<GetStudentDto>>();
            var dbStudents = await _context.Students.ToListAsync();
            var data = dbStudents.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            serviceResponse.Data = data;
            return serviceResponse;
        }
        public  Task<ServiceResponseStudent<List<GetStudentDto>>>EditAStudent(int StudenId)
        {
            var delStudent = Students.FirstOrDefault(s => s.Id == StudenId);
            delStudent.FirstName = "ErickEdited";

            var editedStudents = Students.Select(s=>_mapper.Map<GetStudentDto>(s)).ToList();
            var serviceResponse = new ServiceResponseStudent<List<GetStudentDto>>();
            serviceResponse.Data = editedStudents;
            return Task.FromResult(serviceResponse);
        }
        public Task<ServiceResponseStudent<List<GetStudentDto>>> DeleteAStudetn(int StudenId)
        {
            var newStudents = Students.FirstOrDefault(s => s.Id == StudenId);
            var serviceResponse = new ServiceResponseStudent<List<GetStudentDto>>();
            if (newStudents != null)
            {
                Students.Remove(newStudents);
                serviceResponse.Data = Students.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
                serviceResponse.Message = "Student Deleted";
                return Task.FromResult(serviceResponse);
            }
            else {
                serviceResponse.Message =$"Student with id: {StudenId} not found";
                return Task.FromResult(serviceResponse);
            
            }
       


        }
    }
}
