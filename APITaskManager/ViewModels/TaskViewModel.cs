using APITaskManager.Domain;

namespace APITaskManager.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Utils.TaskStatus Status { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        public string CreatorUserID { get; set; }
        public Project Project { get; set; }
        public List<TaskHistory> TaskHistories { get; set; }
        public List<TaskComment> Comments { get; set; }
    }
}
