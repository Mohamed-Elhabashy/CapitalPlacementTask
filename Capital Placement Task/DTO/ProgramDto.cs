namespace Capital_Placement_Task.DTO
{
    public class ProgramDto
    {
        public int Id { get; set; }
        public string ProgramTitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string KeySkillsRequired { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public int DurationMonths { get; set; }
        public string ProgramLocation { get; set; }
        public string MinQualifications { get; set; }
        public int MaxApplications { get; set; }
    }
}
