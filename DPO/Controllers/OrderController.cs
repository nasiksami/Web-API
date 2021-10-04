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
    public class OrderController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Order
        public IQueryable<tbl_Order> Gettbl_Order()
        {
            return db.tbl_Order;
        }

        // GET: api/Order/5
        [ResponseType(typeof(tbl_Order))]
        public IHttpActionResult Gettbl_Order(int id)
        {
            tbl_Order tbl_Order = db.tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return NotFound();
            }

            return Ok(tbl_Order);
        }


        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Order(int id, tbl_Order tbl_Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Order.order_ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_OrderExists(id))
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

        // POST: api/Order
        [ResponseType(typeof(tbl_Order))]
        public IHttpActionResult Posttbl_Order(tbl_Order tbl_Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            tbl_Order.created_on = DateTime.Now;

            db.tbl_Order.Add(tbl_Order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Order.order_ID }, tbl_Order);
        }

        // DELETE: api/Order/5
        [ResponseType(typeof(tbl_Order))]
        public IHttpActionResult Deletetbl_Order(int id)
        {
            tbl_Order tbl_Order = db.tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return NotFound();
            }

            db.tbl_Order.Remove(tbl_Order);
            db.SaveChanges();

            return Ok(tbl_Order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_OrderExists(int id)
        {
            return db.tbl_Order.Count(e => e.order_ID == id) > 0;
        }
    }
}