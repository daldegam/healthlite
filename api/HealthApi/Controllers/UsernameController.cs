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
    [RoutePrefix("api/username")]
    public class UsernameController : ApiController
    {
        private Models.HealthLiteEntities HealthLiteContext { get; set; }

        public UsernameController()
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
        [Route("auth")]
        [ResponseType(typeof(Models.Username))]
        public IHttpActionResult AuthUsername([FromBody]ViewModel.Username username)
        {
            using (MD5 md5Hash = MD5.Create()) 
            {
                byte[] hashTemp = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(username.password));

                var userData = this.HealthLiteContext.Usernames.Where(x => x.Email == username.email).Where(x => x.Password == hashTemp).FirstOrDefault();

                if (userData == null)
                {
                    return NotFound();
                }

                return Ok(userData);
            }
        }

    }
}
