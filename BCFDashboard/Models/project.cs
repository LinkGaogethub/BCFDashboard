using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RestSharp.Deserializers;

namespace BCFDashboard.Models
{

    public class Project
    {
        //[DeserializeAs(Attribute = false)]
        //public int projectId { get; set; }
        [Key]
        public string project_id { get; set; }
        public string name { get; set; }
        public string bimsync_project_name { get; set; }
        public string bimsync_project_id { get; set; }
    }
}