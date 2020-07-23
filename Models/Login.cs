using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_internet_banking.Models
{
    public class Login
    {
        DB_INTERNET_BANKINGEntities db = new DB_INTERNET_BANKINGEntities();
        public TB_IB_USUARIO DoLogin(string DS_EMAIL, string DS_SENHA)
        {

            TB_IB_USUARIO User = new TB_IB_USUARIO();
            User = db.TB_IB_USUARIO
                    .Where(
                        x => x.DS_EMAIL == DS_EMAIL && x.DS_SENHA == DS_SENHA
                    ).FirstOrDefault();

            return User;

        }
    }
}