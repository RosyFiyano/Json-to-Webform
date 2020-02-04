using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSONtoWebForm.Models
{
    public class jsondata
    {

        public int id { get; set; }
        
        public string name { get; set; }
        
        public string gender { get; set; }
        
        public List<string> hobbie { get; set; }
        //public string hobbie2 { get; set; }
        //public string hobbie3 { get; set; }

    }
}