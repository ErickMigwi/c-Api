namespace c__crash2.Services.StudentServices
{
    public interface StudentServiceInterface
    {
        Task<ServiceResponseStudent<List<GetStudentDto>>> GetStudentDetails();
        Task<ServiceResponseStudent<List<GetStudentDto>>> AddStudentDetailsAsync(AddStudentDto Student);
        Task<ServiceResponseStudent<GetStudentDto>> GetStudentById(int StudenId);
        Task<ServiceResponseStudent<List<GetStudentDto>>> EditAStudent(int StudenId);
        Task<ServiceResponseStudent<List<GetStudentDto>>> DeleteAStudetn(int StudenId);

    }
}
