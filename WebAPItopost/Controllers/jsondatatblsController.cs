using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPItopost.Models;

namespace WebAPItopost.Controllers
{
    public class jsondatatblsController : ApiController
    {
        private jsonEntities db = new jsonEntities();


        // POST: api/jsondatatbls
        [ResponseType(typeof(jsondatatbl))]
        public IHttpActionResult Postjsondatatbl(jsondatatbl jsondatatbl)
        {

            db.jsondatatbls.Add(jsondatatbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jsondatatbl.id }, jsondatatbl);
        }
    }
       
}