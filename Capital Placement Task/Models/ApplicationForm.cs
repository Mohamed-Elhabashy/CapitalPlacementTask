namespace Capital_Placement_Task.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}
