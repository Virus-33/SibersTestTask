using System.ComponentModel.DataAnnotations.Schema;

namespace TTask.Models
{
    public class Project
    {

        public Project()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string ClientCompany {  get; set; }

        public string ExecutorCompany { get; set; }

        public DateOnly StartingDate { get; set; }

        public DateOnly EndingDate { get; set; }
        
        public int ManagerKey {  get; set; }

        [NotMapped]
        public Person ProjectManager { get; set; }

        public List<Person> People { get; set; } = new();

        [NotMapped]
        public List<int> PeopleKeys { get; set; } = new();

        public int Priority {  get; set; }
    }
}
