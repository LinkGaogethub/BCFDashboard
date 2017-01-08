using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCFDashboard.Models;

namespace BCFDashboard.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Retrive values from bimsync, and add them to the database
        public ActionResult GetValues()
        {
            Helpers.BcfApi bcfApi = new Helpers.BcfApi();

            if (ModelState.IsValid)
            {
                List<Models.Project> projects = bcfApi.GetProjects();
                db.Projects.AddRange(projects);

                foreach (Models.Project project in projects)
                {
                    List<Models.Topic> topics = bcfApi.GetTopics(project.project_id);
                    db.Topics.AddRange(topics);

                    foreach (Topic topic in topics)
                    {
                        db.Comments.AddRange(bcfApi.GetComments(project.project_id, topic.guid));
                    }
                }

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}