using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCFDashboard.Models
{

    public class Project
    {
        public int projectId { get; set; }
        public string project_id { get; set; }
        public string name { get; set; }
        public string bimsync_project_name { get; set; }
        public string bimsync_project_id { get; set; }
    }
}