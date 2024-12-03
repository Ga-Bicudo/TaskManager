using APITaskManager.Domain;

namespace APITaskManager.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorUserId { get; set; }
        public User User { get; set; }
        public List<Domain.Task> Tasks { get; set; }
    }
}
