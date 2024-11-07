namespace TTask.Models
{
    public class Project
    {
        public Project(int id, string name, string ccompany, string ecompany, DateOnly sdate, DateOnly edate) 
        {
            Id = id;
            Name = name;
            ClientCompany = ccompany;
            ExecutorCompany = ecompany;
            StartingDate = sdate;
            EndingDate = edate;
        }

        public Project()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string ClientCompany {  get; set; }

        public string ExecutorCompany { get; set; }

        public DateOnly StartingDate { get; set; }

        public DateOnly EndingDate { get; set; }
        
        public Person ProjectManager { get; set; }

        public List<Person> People { get; set; }

        public int Priority {  get; set; }
    }
}
