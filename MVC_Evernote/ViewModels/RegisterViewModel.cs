using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Evernote.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(50,ErrorMessage ="{0} max. {1} karakter olmalıdır")]
        public string Username { get; set; }
        
        [DisplayName("Email"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalıdır"), 
            EmailAddress(ErrorMessage ="{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        
        [DisplayName("Şifre"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalıdır"), 
            DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DisplayName("Şifre Tekrar"), 
            Required(ErrorMessage = "{0} alanı boş geçilemez."), 
            StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalıdır"), 
            DataType(DataType.Password),
            Compare("Password",ErrorMessage ="{0} ile {1} uyuşmuyor")
            ]
        public string RePassword { get; set; } 
    }
}