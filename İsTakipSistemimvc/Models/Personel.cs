using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IsTakipSistemiMvc.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen personel adını giriniz!")] // <-- YENİ EKLENDİ
        public string AdSoyad { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Giriş için kullanıcı adı şarttır!")] // <-- YENİ EKLENDİ
        public string KullaniciAd { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Parola boş bırakılamaz!")] // <-- YENİ EKLENDİ
        public string Parola { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string Telefon { get; set; }

        // İlişkiler
        [Display(Name = "Departman")]
        public int BirimId { get; set; }
        public virtual Birim Birim { get; set; }

        [Display(Name = "Yetki Türü")]
        public int YetkiTurId { get; set; }
        public virtual YetkiTur YetkiTur { get; set; }

        public virtual ICollection<Is> Isler { get; set; }
    }
}