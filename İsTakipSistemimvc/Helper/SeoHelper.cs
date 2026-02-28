using System.Text.RegularExpressions;

namespace IsTakipSistemiMvc.Helper
{
    public class SeoHelper
    {
        public static string ToSeoUrl(string IncomingText)
        {
            if (string.IsNullOrEmpty(IncomingText)) return "";

            IncomingText = IncomingText.ToLower();

            // PDF'teki gibi Türkçe karakterleri değiştiriyoruz
            IncomingText = IncomingText.Replace("ş", "s");
            IncomingText = IncomingText.Replace("ı", "i");
            IncomingText = IncomingText.Replace("ğ", "g");
            IncomingText = IncomingText.Replace("ü", "u");
            IncomingText = IncomingText.Replace("ö", "o");
            IncomingText = IncomingText.Replace("ç", "c");

            // Geçersiz karakterleri sil (Sadece harf, rakam ve tire kalsın)
            IncomingText = Regex.Replace(IncomingText, @"[^a-z0-9\s-]", "");

            // Boşlukları tire (-) ile değiştir
            IncomingText = Regex.Replace(IncomingText, @"\s+", " ").Trim();
            IncomingText = Regex.Replace(IncomingText, @"\s", "-");

            return IncomingText;
        }
    }
}