namespace TodoAPI
{
    public class Task
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueTime { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskState State { get; set; } = TaskState.Todo;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum TaskPriority
    {
        Low,
        Mid,
        High
    }

    public enum TaskState
    {
        Todo,
        InProgress,
        Done
    }
}
