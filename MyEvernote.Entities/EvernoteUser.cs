using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("EvernoteUsers")]
    public class EvernoteUser:MyEntitiyBase
    {
        [DisplayName("İsim"), 
            StringLength(50, ErrorMessage ="{0} alanı max. {1} karater olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyisim"), 
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karater olmalıdır.")]
        public string Surname { get; set; }

        [DisplayName("Kullanıcı Adı"), 
            Required(ErrorMessage ="{0} alanı gereklidir."), 
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karater olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("Email"), 
            Required(ErrorMessage = "{0} alanı gereklidir."), 
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karater olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Şifre"), 
            Required(ErrorMessage = "{0} alanı gereklidir."), 
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karater olmalıdır.")]
        public string Password { get; set; }

        [StringLength(30)]
        public string ProfileImageFileName { get; set; }

        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public virtual List<Note> Notes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
