using System;
using System.ComponentModel.DataAnnotations; // Display özelliğinin çalışması için bu gereklidir

namespace IsTakipSistemiMvc.Models
{
    public class Is
    {
        [Key]
        public int IsId { get; set; }

        [Display(Name = "İş Başlığı")]
        public string Baslik { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Teslim Tarihi")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Tarih { get; set; } = DateTime.Now;

        // --- GÜNCELLEME BURADA ---

        // Ekranda "PersonelId" yerine artık "Personel Adı" yazacak.
        [Display(Name = "Personel Adı")]
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }

        // Ekranda "DurumId" yerine sadece "Durum" yazacak.
        [Display(Name = "Durum")]
        public int DurumId { get; set; }
        public virtual Durum Durum { get; set; }
    }
}