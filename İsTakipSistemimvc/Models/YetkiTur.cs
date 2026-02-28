using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsTakipSistemiMvc.Models
{
    public class YetkiTur
    {
        [Key]
        public int YetkiTurId { get; set; }

        [Display(Name = "Yetki Adı")]
        public string YetkiAd { get; set; }

        public virtual ICollection<Personel> Personeller { get; set; }
    }
}