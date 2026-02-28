using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsTakipSistemiMvc.Models
{
    public class Durum
    {
        [Key]
        public int DurumId { get; set; }

        [Display(Name = "Durum Adı")]
        public string DurumAd { get; set; }

        public virtual ICollection<Is> Isler { get; set; }
    }
}