using System.Linq;
using System.Web.Mvc;
using System.Data.Entity; // Include işlemi için bu kütüphane şart
using IsTakipSistemiMvc.Models;

namespace IsTakipSistemiMvc.Controllers
{
    public class HomeController : Controller
    {
        // Veritabanı bağlantısını tekrar açtık
        IsTakipContext db = new IsTakipContext();

        public ActionResult Index()
        {
            // Verileri "Include" ile (İlişkili tablolarla beraber) çekiyoruz.
       
            var isler = db.Isler.Include("Personel").Include("Durum").ToList();

            return View(isler);
        }
    }
}