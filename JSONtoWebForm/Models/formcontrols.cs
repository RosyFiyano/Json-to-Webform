using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSONtoWebForm.Models
{
    public class formcontrols
    {
        public string type{ get; set; }
        public string label{ get; set; }
        public string[] options{ get; set; }

    }
    public class ctrls
    {
        public List<formcontrols> controls { get; set; }
    }

}