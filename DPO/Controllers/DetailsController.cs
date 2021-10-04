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
using DPO.Models;

namespace DPO.Controllers
{
    public class DetailsController : ApiController
    {  
        private DBModel db = new DBModel();

        // GET: api/details
        public IQueryable<tbl_Details> Gettbl_Details()
        {
            return db.tbl_Details;
        }


        // GET: api/details/5
        [ResponseType(typeof(tbl_Details))]
        public IHttpActionResult Gettbl_Details(int id)
        {
            tbl_Details tbl_Details = db.tbl_Details.Find(id);
            if (tbl_Details == null)
            {
                return NotFound();
            }

            return Ok(tbl_Details);
        }


        public IEnumerable<tbl_Details> Gettbl_Orders(int order_ID)
        {
            var list = from g in db.tbl_Details where g.order_ID == order_ID select g;
            return list;
        }












        // POST: api/details
        [ResponseType(typeof(tbl_Details))]
        public IHttpActionResult Posttbl_Details(tbl_Details tbl_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbl_Details.created_On = DateTime.Now;
            db.tbl_Details.Add(tbl_Details);

            //geting order status by order ID
            var mainOrder = db.tbl_Order.Find(tbl_Details.order_ID);
            var orderStatus = mainOrder.status;
            tbl_Details.status = orderStatus;


            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = tbl_Details.ID }, tbl_Details);
        }





            // PUT: api/details/5
            [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Details(int id, tbl_Details tbl_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Details.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_DetailsExists(id))
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

       
        // DELETE: api/details/5
        [ResponseType(typeof(tbl_Details))]
        public IHttpActionResult Deletetbl_Details(int id)
        {
            tbl_Details tbl_Details = db.tbl_Details.Find(id);
            if (tbl_Details == null)
            {
                return NotFound();
            }

            db.tbl_Details.Remove(tbl_Details);
            db.SaveChanges();

            return Ok(tbl_Details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_DetailsExists(int id)
        {
            return db.tbl_Details.Count(e => e.ID == id) > 0;
        }
    }
}