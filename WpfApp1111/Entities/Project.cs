namespace WpfApp1111.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
