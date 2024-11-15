using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewPage()
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

        [HttpPost]
        [Route("Home/form")]
        public IActionResult PersonSearch(string searchstring)
        {
            var all_persons = db.People.Where(a => (a.Surname + " " + a.Name + " " + a.Patronymic).Contains(searchstring)).ToList();

            if (all_persons.Count == 0)
            {
                return NotFound();
            }

            return PartialView(all_persons);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
