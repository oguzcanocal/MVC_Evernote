using MVC_Evernote.Models;
using MyEvernote.Common;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Evernote
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            EvernoteUser user = CurrentSession.User;

            if (user != null)
            {
                return user.Username;
            }

            else
            {
                return "system";
            }

            
        }
    }
}