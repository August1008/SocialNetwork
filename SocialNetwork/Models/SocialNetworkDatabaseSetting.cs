namespace SocialNetwork.Models
{
    public class SocialNetworkDatabaseSetting : ISocialNetworkDatabaseSetting
    {
        public string RegistrationCollection { get; set; } = String.Empty;
        public string ArticleCollection { get; set; } = string.Empty;
        public string NewCollection { get; set; } = string.Empty;
        public string EventCollection { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}
