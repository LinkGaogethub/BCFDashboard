using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCFDashboard.Helpers
{
    public class Requester
    {
        private string GetAPIVersion()
        {

            return "beta";
        }

        private  string bimsyncURL { get; set; }
    }
}