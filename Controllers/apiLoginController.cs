using api_internet_banking.Models;
using api_internet_banking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_internet_banking.Controllers
{
    [RoutePrefix("api/user")]
    public class apiLoginController : ApiController
    {
        UtilsController util = new UtilsController();

        [Route ("doLogin")]
        [HttpGet]
        public HttpResponseMessage doLogin(string DS_EMAIL, string DS_SENHA)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    DS_SENHA = util.CalculateSHA1(DS_SENHA);
                    TB_IB_USUARIO User = new TB_IB_USUARIO();
                    Login l = new Login();
                    TokenService t = new TokenService();
                    User = l.DoLogin(DS_EMAIL, DS_SENHA);
                    
                    if(User != null)
                    {
                         string token = t.GenerateToken(User);
                         return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, userData = User, token });
                    }
                        
                    else
                        return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, message = "Usuário ou senha inválidos!"});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = "Por favor preencha todos os campos!" });
                }
            }
            catch(Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = err });
            }
        }
    }
}
