namespace Video.Renaming.Common.Models
{
    public class AppSettings
    {
        public OMDbSettings OMDb { get; set; }
        public static readonly string Section = "App";
    }

    public class OMDbSettings
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
    }
}