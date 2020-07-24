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
            TB_IB_HISTORICO_ACESSO UserHist = new TB_IB_HISTORICO_ACESSO();

            User = db.TB_IB_USUARIO
                    .Where(
                        x => x.DS_EMAIL == DS_EMAIL && x.DS_SENHA == DS_SENHA
                    ).FirstOrDefault();

            if(User != null)
            {
                UserHist.ID_USUARIO = User.ID_USUARIO;
                UserHist.DT_ACESSO = DateTime.Now;
                db.TB_IB_HISTORICO_ACESSO.Add(UserHist);
                db.SaveChanges();
            }

            return User;

        }

        public void Register (TB_IB_USUARIO UserData)
        {
            try
            {
                db.TB_IB_USUARIO.Add(UserData);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}