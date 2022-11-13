namespace GeradorURL.Model
{
    public class Url
    {
        public int Id { get; set; }
        public string UrlLonga { get; set; } = string.Empty;
        public string UrlCurta { get; set; } = string.Empty;

        public Url(string urlLonga, string urlCurta)
        {
            UrlLonga = urlLonga;
            UrlCurta = urlCurta;
        }
    }
}
