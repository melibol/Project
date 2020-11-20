using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.DTOs
{
   public class UserDto
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.")]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz.")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [Display(Name = "Email Adresiniz.")]
        [EmailAddress(ErrorMessage = "Emailiniz yanlış formatta.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        [Display(Name = "Soyad")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        //public int Id { get; set; }


    }
}
