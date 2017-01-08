using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCFDashboard.Models
{
    public class Comment
    {
        //public  int commentID { get; set; }
        [Key]
        public string guid { get; set; }
        public string verbal_status { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public string author { get; set; }
        public string comment { get; set; }
        public string topic_guid { get; set; }
        public string viewpoint_guid { get; set; }
    }
}