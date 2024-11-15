
namespace TTask.Models
{
    public class Person
    {
        public Person(int id, string name, string surname, string patronymic, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
        }

        public Person()
        {
            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public Project ManagingProject { get; set; }

        public List<Project> Projects { get; set; } = new();

        public Roles Role {
            get; set; 
        }

        public enum Roles : int
        {
            Employee = 0,
            Manager = 1,
            CEO = 2
        }
    }
}
