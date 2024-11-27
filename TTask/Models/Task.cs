using System.ComponentModel.DataAnnotations.Schema;

namespace TTask.Models
{
    public class Task
    {
        public Task() { }

        public int Id { get; set; }
        public string Name { get; set; }

        public Person Autor { get; set; }

        public Person Executor { get; set; }

        [NotMapped]
        public int AutorId { get; set; }

        [NotMapped]
        public int ExecutorId { get; set; }

        public StatusID Status { get; set; }

        public string Commentary { get; set; }

        public int Priority { get; set; }
        
        [NotMapped]
        public Project Project { get; set; }

        public int ProjectKey { get; set; }

        public enum StatusID
        {
            ToDo,
            InProgress,
            Done
        }
    }
}
