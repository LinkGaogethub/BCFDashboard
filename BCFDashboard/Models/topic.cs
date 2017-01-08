using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BCFDashboard.Models
{
    public class Topic
    {
        //public int topicId { get; set; }
        //public int projectId { get; set; }
        [Key]
        public string guid { get; set; }
        public string topic_type { get; set; }
        public string topic_status { get; set; }
        public string title { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime modified_date { get; set; }
        public string modified_author { get; set; }
        public string assigned_to { get; set; }
    }
}