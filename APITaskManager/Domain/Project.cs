namespace APITaskManager.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorUserId { get; set; }  
        public User User { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
