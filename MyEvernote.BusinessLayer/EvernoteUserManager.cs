using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using MyEvernote.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class EvernoteUserManager
    {
        private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        public BusinessLayerResult<EvernoteUser> RegisterUser(RegisterViewModel data)
        {
            EvernoteUser user =  repo_user.Find(x => x.Username == data.Username || x.Email == data.Email );
            BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();

            if (user != null)
            {
                if(user.Username == data.Username)
                {
                    res.Errors.Add("Kullanıcı adı kayıtlıdır");
                }
                if (user.Email == data.Email)
                {
                    res.Errors.Add("Mail adresi kayıtlıdır");
                }
            }
            else
            {
                int dbResult = repo_user.Insert(new EvernoteUser()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    IsAdmin = false

                    
                });

                if (dbResult > 0)
                {
                    repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);

                    
                }

            }

            return res;
        }


        public BusinessLayerResult<EvernoteUser> LoginUser(LoginViewModel data)
        {
            EvernoteUser user = repo_user.Find(x => x.Username == data.Username && x.Password == data.Password);
            BusinessLayerResult<EvernoteUser> res = new BusinessLayerResult<EvernoteUser>();

            res.Result = user;

            if (user != null)
            {
                if (!user.IsActive)
                {
                    res.Errors.Add("Kullanıcı aktifleştirilmemiştir. Lütfen e-posta adresinizi kontrol ediniz.");
                }
                
            }

            else
            {
                res.Errors.Add("Kullanıcı adı ve şifre uyuşmuyor.");
            }
           

            return res;
        }

    }
}
