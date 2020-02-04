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
using webAPI.Models;

namespace webAPI.Controllers
{
    public class jsondatatblsController : ApiController
    {
        private jsonEntities db = new jsonEntities();

        // GET: api/jsondatatbls
        public IQueryable<jsondatatbl> Getjsondatatbls()
        {
            return db.jsondatatbls;
        }

        // GET: api/jsondatatbls/5
        [ResponseType(typeof(jsondatatbl))]
        public IHttpActionResult Getjsondatatbl(int id)
        {
            jsondatatbl jsondatatbl = db.jsondatatbls.Find(id);
            if (jsondatatbl == null)
            {
                return NotFound();
            }

            return Ok(jsondatatbl);
        }

        // PUT: api/jsondatatbls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putjsondatatbl(int id, jsondatatbl jsondatatbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jsondatatbl.id)
            {
                return BadRequest();
            }

            db.Entry(jsondatatbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jsondatatblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/jsondatatbls
        [ResponseType(typeof(jsondatatbl))]
        public IHttpActionResult Postjsondatatbl(jsondatatbl jsondatatbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.jsondatatbls.Add(jsondatatbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jsondatatbl.id }, jsondatatbl);
        }

        // DELETE: api/jsondatatbls/5
        [ResponseType(typeof(jsondatatbl))]
        public IHttpActionResult Deletejsondatatbl(int id)
        {
            jsondatatbl jsondatatbl = db.jsondatatbls.Find(id);
            if (jsondatatbl == null)
            {
                return NotFound();
            }

            db.jsondatatbls.Remove(jsondatatbl);
            db.SaveChanges();

            return Ok(jsondatatbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool jsondatatblExists(int id)
        {
            return db.jsondatatbls.Count(e => e.id == id) > 0;
        }
    }
}