using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using JSONtoWebForm.Models;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Web.UI;

namespace JSONtoWebForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult readJSON(HttpPostedFileBase jfile)
        {
            if (ModelState.IsValid==true)
            {
                jfile.SaveAs(Server.MapPath("~/jsonfile/" + Path.GetFileName(jfile.FileName)));
                string file = Path.GetFileName(jfile.FileName);
                StreamReader rdr = new StreamReader(Server.MapPath("~/jsonfile/" + Path.GetFileName(jfile.FileName)));
                string jdata = rdr.ReadToEnd();
                //var dataread = JsonConvert.DeserializeObject<formcontrols>(jdata);
                //// ViewBag.datatoc=datas;
                //return RedirectToAction("controls",new { file });
                JavaScriptSerializer jss = new JavaScriptSerializer();
                List<formcontrols> fcrls = (List<formcontrols>)jss.Deserialize(jdata, typeof(List<formcontrols>));

                return View(fcrls);
            }
            else
                return View("Index");

        }
        [HttpPost]
        public ActionResult save(jsondata jdata)
        {
            if (ModelState.IsValid == true)
            {
                jsondatatbl tbl = new jsondatatbl();
                tbl.name = jdata.name;
                tbl.gender = jdata.gender;

                if (jdata.hobbie.Count != 0)
                {
                    for (int i = 0; i < jdata.hobbie.Count; i++)
                    {
                        if (i == 0)
                            tbl.hobbie1 = jdata.hobbie[0];
                        if (i == 1)
                            tbl.hobbie2 = jdata.hobbie[1];
                        if (i == 2)
                            tbl.hobbie3 = jdata.hobbie[2];
                    }
                }
                else
                {
                    tbl.hobbie1 = "NULL";
                    tbl.hobbie2 = "NULL";
                    tbl.hobbie3 = "NULL";
                }

                HttpResponseMessage response = global.webclient.PostAsJsonAsync("jsondatatbls", tbl).Result;

                return View(tbl);
            }
            else
            {
               
                return View("~/Views/Home/readJSON.cshtml");
            }

        }

    }
}
