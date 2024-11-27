using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TTask.Models;

namespace TTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskRedactor()
        {
            ViewBag.Tasks = db.Tasks.ToList();

            ViewBag.People = db.People.ToList();
            ViewBag.Projects = db.Projects.ToList();

            return View();
        }


        public IActionResult AddTask()
        {
            ViewBag.People = db.People.ToList();
            ViewBag.Projects = db.Projects.ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProjectCreationWizard()
        {
            ViewBag.People = db.People.ToList();

            return View();
        }

        public IActionResult CreatePerson()
        {
            return View();
        }

        public IActionResult PersonRedactor()
        {
            ViewBag.People = db.People.ToList();

            return View();
        }

        public IActionResult ProjectRedactor()
        {
            ViewBag.People = db.People.ToList();
            ViewBag.Projects = db.Projects.ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RedactPerson(Person person)
        {
            db.People.Remove(db.People.Where(i => i.Id == person.Id).First());
            db.People.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeTask(Models.Task task)
        {
            db.Tasks.Remove(db.Tasks.Where(i => i.Id == task.Id).First());
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            db.People.Add(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            foreach (int pid in project.PeopleKeys)
            {
                project.People.Add(db.People.Where(i=> i.Id == pid).First());
            }

            project.ProjectManager = db.People.Where(i=>i.Id == project.ManagerKey).First();

            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
