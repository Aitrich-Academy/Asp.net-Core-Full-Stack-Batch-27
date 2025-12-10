namespace HireMeNow.Dto
{
    public class JobDto
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Experience { get; set; }
        public string? JobType { get; set; }
        public string? Salary { get; set; }

        public string? CompanyName { get; set; }
        public Guid CompanyId { get; set; }

       
        public JobDto(string title, string description, string location, string salary, Guid companyId, string company, Guid? id = null)
        {
            Id = id ?? new Guid();

            Title = title;
            Description = description;
            Location = location;
            Salary = salary;

            CompanyName = company;
            CompanyId = companyId;
        }

        public JobDto()
        {
        }
    }
}
