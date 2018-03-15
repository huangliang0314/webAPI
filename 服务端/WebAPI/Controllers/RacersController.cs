using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebAPI.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Racer>("Racers");
    builder.EntitySet<RaceResult>("RaceResultSet"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RacersController : ODataController
    {
        private FormulaModel1Container db = new FormulaModel1Container();

        // GET: odata/Racers
        [EnableQuery]
        public IQueryable<Racer> GetRacers()
        {
            return db.RacerSet;
        }

        // GET: odata/Racers(5)
        [EnableQuery]
        public SingleResult<Racer> GetRacer([FromODataUri] int key)
        {
            return SingleResult.Create(db.RacerSet.Where(racer => racer.Id == key));
        }

        // PUT: odata/Racers(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Racer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Racer racer = db.RacerSet.Find(key);
            if (racer == null)
            {
                return NotFound();
            }

            patch.Put(racer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(racer);
        }

        // POST: odata/Racers
        public IHttpActionResult Post(Racer racer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RacerSet.Add(racer);
            db.SaveChanges();

            return Created(racer);
        }

        // PATCH: odata/Racers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Racer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Racer racer = db.RacerSet.Find(key);
            if (racer == null)
            {
                return NotFound();
            }

            patch.Patch(racer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(racer);
        }

        // DELETE: odata/Racers(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Racer racer = db.RacerSet.Find(key);
            if (racer == null)
            {
                return NotFound();
            }

            db.RacerSet.Remove(racer);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Racers(5)/RaceResult
        [EnableQuery]
        public IQueryable<RaceResult> GetRaceResult([FromODataUri] int key)
        {
            return db.RacerSet.Where(m => m.Id == key).SelectMany(m => m.RaceResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RacerExists(int key)
        {
            return db.RacerSet.Count(e => e.Id == key) > 0;
        }
    }
}
