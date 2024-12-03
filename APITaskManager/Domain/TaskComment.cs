namespace APITaskManager.Domain
{
    public class TaskComment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}
