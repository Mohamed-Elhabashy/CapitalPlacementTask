namespace Capital_Placement_Task.Models
{
    public class InterviewStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeStage Type { get; set; }
        public string Attributes { get; set; } // JSON string for custom attributes
    }
    public enum TypeStage
    {
        Shortlisting,
        VideoInterview,
        Placement
    }
}
