using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.ViewModels
{
    public class UserRegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Firma Adı", Prompt = "Bilge Adam")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Telefon Numarası", Prompt = "12345678901")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="{0} {1} karakterli olmalıdır")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez.")]
        [Display(Name = "Adres")]
        [MinLength(20, ErrorMessage = "Lütfen daha ayrıntılı bir adres bilgisi giriniz.")]
        public string Address { get; set; }
    }
}
