using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aisys.Application.Login;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aisys.Web.Host.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        [HttpPost("verifyPassword")]
        public VerifyPasswordOutput verifyPassword(VerifyPasswordInput input)
        {
            var baseDate = new DateTime(1970, 01, 01);
            VerifyPasswordOutput output = new VerifyPasswordOutput()
            {
                idToken = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                localId = "123456",
                expiresIn = Convert.ToInt32(DateTime.Now.AddDays(3).Subtract(baseDate).TotalSeconds)
            };

            return output;
        }
    }
}