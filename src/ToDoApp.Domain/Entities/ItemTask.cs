
using System;

namespace ToDoApp.Domain.Entities
{
    public class ItemTask: BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public ItemTask(string title, string description)
        {
            SetTitle(title);
            SetDescription(description);
        }

        public void CompleteTask()
        {
            IsCompleted = true;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description ?? string.Empty;
        }
    }
}
