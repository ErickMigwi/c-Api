namespace c__crash2.DTOS.StudentDTO
{
    public class AddStudentDto
    {
        public int Id { get; set; } = 1;
        public string FirstName { get; set; } = "Erick";
        public string LastName { get; set; } = "Migwi";
        public string Course { get; set; } = "Software Development";
        public int Year { get; set; } = 3;
        public char Grade { get; set; } = 'A';
        public string ParentFullName { get; set; } = "Peter Muthiga";
        public string Allergies { get; set; } = "None";
    }
}
