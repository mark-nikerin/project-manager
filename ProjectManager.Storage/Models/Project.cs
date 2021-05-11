using System;
using System.Collections.Generic;
using ProjectManager.Storage.Enums;

namespace ProjectManager.Storage.Models
{
    public class Project
    {
        public Project()
        {
            Boards = new HashSet<Board>();
            Iterations = new HashSet<Iteration>();
            TaskStatuses = new HashSet<TaskStatus>();
            TaskTags = new HashSet<TaskTag>();
            TaskTypes = new HashSet<TaskType>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Prefix { get; set; }

        public ProjectType Type { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Iteration> Iterations { get; set; }
        public virtual ICollection<TaskStatus> TaskStatuses { get; set; }
        public virtual ICollection<TaskTag> TaskTags { get; set; }
        public virtual ICollection<TaskType> TaskTypes { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}