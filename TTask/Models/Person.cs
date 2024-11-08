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

        private Roles role;
        public Roles Role { 
            get 
            { 
                return role; 
            } 
            set 
            { 
                if (value.GetType() == typeof(string))
                {

                }
            } 
        }

        public enum Roles : int
        {
            Employee = 0,
            Manager = 1,
            CEO = 2
        }
    }
}
