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

        public async Task<InvoiceModel> GetInvoiceAsync(int price)
        {
            var redirectURL = _configurationComponent.GetApplicationUrl();

            var client = new BTCPayServerClient(new Uri(_configurationComponent.GetBtcPayServerUrl()), _configurationComponent.GetBtcPayApiKey());
            var invoice = await client.CreateInvoice("FkRSUeStjPEtNJPWEEvEJPUyVCL3KcG3D1PxbSpuQZpL", new BTCPayServer.Client.Models.CreateInvoiceRequest
            {
                Amount = price,
                Currency = "CHF"
            });

            return new InvoiceModel
            {
                ResponseContent = invoice.ToString()
            };
        }
    }
}
