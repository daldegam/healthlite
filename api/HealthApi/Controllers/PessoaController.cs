using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace HealthApi.Controllers
{
    [RoutePrefix("api/pessoa")]
    public class PessoaController : ApiController
    {
        private Models.HealthLiteEntities HealthLiteContext { get; set; }

        public PessoaController()
        {
            this.HealthLiteContext = new Models.HealthLiteEntities();
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                this.HealthLiteContext.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [Route("autenticar")]
        [ResponseType(typeof(Models.Pessoa))]
        public IHttpActionResult AuthUsername([FromBody]ViewModel.Pessoa username)
        {
            using (MD5 md5Hash = MD5.Create()) 
            {
                byte[] hashTemp = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(username.Senha));

                var userData = this.HealthLiteContext.Pessoas.Where(x => x.Email == username.Email).Where(x => x.Senha == hashTemp).FirstOrDefault();

                if (userData == null)
                {
                    return NotFound();
                }

                return Ok(userData);
            }
        }

    }
}
