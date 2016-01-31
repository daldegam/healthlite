using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            if (disposing)
            {
                this.HealthLiteContext.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        [ResponseType(typeof(Models.Pessoa))]
        public IHttpActionResult ObtemPessoa(string email, string senha)
        {
            var userData = this.HealthLiteContext.Pessoas.Include("Remedios").Where(x => x.Email == email).Where(x => x.Senha == senha).FirstOrDefault();

            if (userData == null)
            {
                return NotFound();
            }

            return Ok(userData);
        }

        [HttpPost]
        [ResponseType(typeof(Models.Pessoa))]
        public async Task<IHttpActionResult> NovaPessoa(Models.Pessoa pessoa)
        {
            var testEmail = this.HealthLiteContext.Pessoas.Where(x => x.Email == pessoa.Email).FirstOrDefault();
            if (testEmail != null)
            {
                ModelState.AddModelError("Email", "Email já existente");
                return BadRequest(ModelState);
            }

            pessoa.ApiToken = Guid.NewGuid().ToString();

            this.HealthLiteContext.Pessoas.Add(pessoa);

            await this.HealthLiteContext.SaveChangesAsync();

            return Ok(pessoa);
        }

        [HttpPut]
        [ResponseType(typeof(Models.Pessoa))]
        public async Task<IHttpActionResult> EditarPessoa(Models.Pessoa pessoa)
        {
            var auth = this.HealthLiteContext.Pessoas.Where(x => x.PessoaId == pessoa.PessoaId).Where(x => x.ApiToken == pessoa.ApiToken).FirstOrDefault();
            if (auth == null)
            {
                return Unauthorized();
            }

            auth = pessoa;

            await this.HealthLiteContext.SaveChangesAsync();

            return Ok(pessoa);
        }

    }
}
