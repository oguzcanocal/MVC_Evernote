using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Evernote.ViewModel
{
    public class OkViewModel:NotifyViewModelBase<string>
    {
        public OkViewModel()
        {
            Title = "İşlem Başarılı.";

        }
    }
}