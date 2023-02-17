namespace SocialNetwork.Models
{
    public interface ISocialNetworkDatabaseSetting
    {
        public string RegistrationCollection { get; set; }
        public string ArticleCollection { get; set; }
        public string NewCollection { get; set; }
        public string EventCollection { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }

    }
}
