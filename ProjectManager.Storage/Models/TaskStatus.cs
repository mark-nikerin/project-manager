using System.Collections.Generic;

namespace ProjectManager.Storage.Models
{
    public class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}