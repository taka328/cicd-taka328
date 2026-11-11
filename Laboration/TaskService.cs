namespace Laboration
{
    public class TaskService
    {
        private readonly List<TaskItem> tasks =
        [
            new TaskItem(1, "Read the assignment", false),
        new TaskItem(2, "Write backend tests", false),
        new TaskItem(3, "Configure CI/CD", false)
        ];

        private int nextId = 4;

        public IReadOnlyList<TaskItem> GetAll()
        {
            return tasks.AsReadOnly();
        }

        public TaskItem? GetById(int id)
        {
            return tasks.FirstOrDefault(task => task.Id == id);
        }

        public TaskItem Create(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is required.", nameof(title));
            }

            var task = new TaskItem(nextId++, title.Trim(), false);
            tasks.Add(task);
            return task;
        }

        public bool Complete(int id)
        {
            var index = tasks.FindIndex(task => task.Id == id);
            if (index < 0)
            {
                return false;
            }

            var existingTask = tasks[index];
            tasks[index] = existingTask with
            {
                IsCompleted = true
            };

            return true;
        }
    }
}
