using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace HealthApi.Controllers
{
    /// <summary>
    /// Para o produto minimo viável não estão sendo consideradas as
    /// devidas políticas de segurança como checagem do token da api.
    /// </summary>
    [RoutePrefix("api/remedio")]
    public class RemedioController : ApiController
    {
        private Models.HealthLiteEntities HealthLiteContext { get; set; }

        public RemedioController()
        {
            this.HealthLiteContext = new Models.HealthLiteEntities();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.HealthLiteContext.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ResponseType(typeof(Models.Remedio))]
        public IHttpActionResult AddRemedio(Models.Remedio remedio)
        {
            this.HealthLiteContext.Remedios.Add(remedio);
            this.HealthLiteContext.SaveChanges();

            return Ok(remedio);
        }

        [HttpPut]
        [ResponseType(typeof(Models.Remedio))]
        public IHttpActionResult EditRemedio(Models.Remedio remedio)
        {
            // TODO: Testar Token de segurança

            var data = this.HealthLiteContext.Remedios.Where(x => x.RemedioId == remedio.RemedioId).Where(x => x.PessoaId == remedio.PessoaId).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }

            data = remedio;

            this.HealthLiteContext.SaveChanges();
            return Ok(remedio);
        }

        [HttpPut]
        [ResponseType(typeof(Models.Remedio))]
        public IHttpActionResult UpdateAdministrado(int id)
        {
            // Todo: Testar Token de segurança

            var remedio = this.HealthLiteContext.Remedios.Where(x => x.RemedioId == id).First();
            if (remedio == null)
            {
                return NotFound();
            }

            remedio.DataUltimaDoseAdministrada = DateTime.Now;

            this.HealthLiteContext.SaveChanges();

            return Ok(remedio);
        }

        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteRemedio(int id)
        {
            // Todo: Testar Token de segurança

            var remedio = this.HealthLiteContext.Remedios.Where(x => x.RemedioId == id).First();
            if (remedio == null)
            {
                return NotFound();
            }

            this.HealthLiteContext.Entry(remedio).State = System.Data.Entity.EntityState.Deleted;

            this.HealthLiteContext.SaveChanges();

            return Ok();
        }
    }
}
