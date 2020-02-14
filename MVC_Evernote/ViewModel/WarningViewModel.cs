using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Evernote.ViewModel
{
    public class WarningViewModel:NotifyViewModelBase<string>
    {
        public WarningViewModel()
        {
            Title = "Uyarı";
        }
    }
}