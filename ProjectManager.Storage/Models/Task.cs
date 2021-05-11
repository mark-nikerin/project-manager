using System;
using System.Collections.Generic;
using ProjectManager.Storage.Enums;

namespace ProjectManager.Storage.Models
{
    public class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
            LinkedTasks = new HashSet<Task>();
            Tags = new HashSet<TaskTag>();
            WorkTimeRecords = new HashSet<WorkTimeRecord>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public DateTimeOffset DueToDate { get; set; }


        public int? AssigneeId { get; set; }

        public int? ReporterId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public int? BoardId { get; set; }

        public int? IterationId { get; set; }

        public int? ParentTaskId { get; set; }


        public virtual User Assignee { get; set; }

        public virtual User Reporter { get; set; }

        public virtual TaskType Type { get; set; }

        public virtual TaskStatus Status { get; set; }

        public virtual Board Board { get; set; }

        public virtual Iteration Iteration { get; set; }

        public virtual Task ParentTask { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Task> LinkedTasks { get; set; }

        public virtual ICollection<TaskTag> Tags { get; set; }

        public virtual ICollection<WorkTimeRecord> WorkTimeRecords { get; set; }
    }
}