using System;
using System.Collections.Generic;

namespace ProjectManager.Storage.Models
{
    public class Iteration
    {
        public Iteration()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}