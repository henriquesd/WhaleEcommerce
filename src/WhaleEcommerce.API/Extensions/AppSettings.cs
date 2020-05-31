namespace WhaleEcommerce.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string EmittedBy { get; set; }
        public string ValidIn { get; set; }
    }
}