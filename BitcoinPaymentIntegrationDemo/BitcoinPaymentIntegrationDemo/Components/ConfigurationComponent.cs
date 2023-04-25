namespace BitcoinPaymentIntegrationDemo.Components
{
    public class ConfigurationComponent
    {
        private readonly IConfiguration _configuration;

        public ConfigurationComponent()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public string GetBtcPayServerUrl()
        {
            return _configuration.GetSection("BTCPayServer").GetValue<string>("ServerURL");
        }

        public string GetBtcPayApiKey()
        {
            return _configuration.GetSection("BTCPayServer").GetValue<string>("APIKey");
        }

        internal string GetStoreId()
        {
            return _configuration.GetSection("BTCPayServer").GetValue<string>("StoreId");
        }

        internal string GetApplicationUrl()
        {
            return _configuration.GetValue<string>("ApplicationUrl");
        }
    }
}
