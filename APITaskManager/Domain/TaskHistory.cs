namespace APITaskManager.Domain
{
    public class TaskHistory
    {
        public int Id { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime ChangeDate { get; set; }
        public int TaskId { get; set; }
        public string CreatorUserId { get; set; }
    }
}
