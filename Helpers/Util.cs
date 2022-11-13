using System.Text;

namespace GeradorURL.Helpers
{
    public class Util
    {
        public static string generateUrlCurta() 
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var sb = new StringBuilder();                        

            for (int i = 0; i < 8; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            string urlCurta = sb.ToString();

            return urlCurta;
        }

        public static bool IsUrlValid(string url)
        {
            bool teste = Uri.IsWellFormedUriString(url, UriKind.Absolute);
            return teste;
        }
    }
}
