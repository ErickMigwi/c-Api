namespace c__crash2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
        
        CreateMap<STUDENT, GetStudentDto>();
        CreateMap<STUDENT, AddStudentDto>();
        CreateMap<AddStudentDto, STUDENT>();
        }

    }
}
