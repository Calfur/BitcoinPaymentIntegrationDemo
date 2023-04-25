using BitcoinPaymentIntegrationDemo.Models;
using BTCPayServer.Client;

namespace BitcoinPaymentIntegrationDemo.Components
{
    public class InvoiceComponent
    {
        private readonly ConfigurationComponent _configurationComponent;

        public InvoiceComponent()
        {
            _configurationComponent = new ConfigurationComponent();
        }

        public async Task<InvoiceModel> GetInvoiceAsync(decimal price)
        {
            var redirectURL = _configurationComponent.GetApplicationUrl();

            var client = new BTCPayServerClient(new Uri(_configurationComponent.GetBtcPayServerUrl()), _configurationComponent.GetBtcPayApiKey());
            var invoice = await client.CreateInvoice(_configurationComponent.GetStoreId(), new BTCPayServer.Client.Models.CreateInvoiceRequest
            {
                Amount = price,
                Currency = "CHF",
                Checkout = new BTCPayServer.Client.Models.InvoiceDataBase.CheckoutOptions
                {
                    RedirectURL = redirectURL
                }
            });

            return new InvoiceModel
            {
                CheckoutLink = invoice.CheckoutLink
            };
        }
    }
}
