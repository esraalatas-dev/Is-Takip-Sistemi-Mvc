using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsTakipSistemiMvc.Models
{
    public class Birim
    {
        [Key]
        public int BirimId { get; set; }

        [Display(Name = "Birim Adı")]
        public string BirimAd { get; set; }

        // Bir birimde birden fazla personel olabilir (İlişki)
        public virtual ICollection<Personel> Personeller { get; set; }
    }
}

