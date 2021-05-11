using System.Collections.Generic;
using ProjectManager.Storage.Enums;

namespace ProjectManager.Storage.Models
{
    public class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Projects = new HashSet<Project>();
            AssignedTasks = new HashSet<Task>();
            ReportedTasks = new HashSet<Task>();
            WorkTimeRecords = new HashSet<WorkTimeRecord>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Task> AssignedTasks { get; set; }

        public virtual ICollection<Task> ReportedTasks { get; set; }

        public virtual ICollection<WorkTimeRecord> WorkTimeRecords { get; set; }
    }
}