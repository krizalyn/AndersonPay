using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction   
{
  public class FClient : IFClient
    {
        private IDClient _iDClient;

        public FClient(IDClient iDClient)
        {
            _iDClient = iDClient;
        }

        public FClient()
        {
            _iDClient = new DClient();
        }

        #region CREATE
        public Client Create(Client client)
        {
            EClient eClient = EClient(client);
            eClient = _iDClient.Create(eClient);
            return Client(eClient);
        }
        #endregion

        #region READ
        public Client Read(int clientId)
        {
            EClient eClient = _iDClient.Read<EClient>(a => a.ClientId == clientId);
            return Client(eClient);
        }

        public List<Client> Read()
        {
            List<EClient> eClient = _iDClient.List<EClient>(a => true);
            return Client(eClient);
        }
        #endregion

        #region UPDATE
        public Client Update(Client client)
        {
            var eClient = _iDClient.Update(EClient(client));
            return (Client (eClient));
        }
        #endregion

        #region DELETE
        public void Delete(Client client)
        {
            _iDClient.Delete(EClient(client));
        }
        #endregion

        #region OTHER FUNCTION
        private EClient EClient(Client client)
        {
            EClient returnEClient = new EClient 
            {

                Code = client.Code,

                ClientId = client.ClientId,
                Address = client.Address,
                CompanyId = client.CompanyId,
                RegistrationNumber = client.RegistrationNumber,
                TaxTypeId = client.TaxTypeId,
            //    TaxType1 = client.TaxType1,
                Registration = client.Registration,
                
                WithHoldingTaxPercentage = client.WithHoldingTaxPercentage,
                CurrencyCode = client.CurrencyCode,
                Name = client.Name

            };
            return returnEClient;
        }

        private Client Client(EClient eClient)
        {
            Client returnClient = new Client

            {
                Code = eClient.Code,
                email1 = eClient.email1,
                email2 = eClient.email2,
                email3 = eClient.email3,

                Registration = eClient.Registration,
                ClientId = eClient.ClientId,
                Address = eClient.Address,
                CompanyId = eClient.CompanyId,
                RegistrationNumber = eClient.RegistrationNumber,
                TaxTypeId = eClient.TaxTypeId,
                WithHoldingTaxPercentage = eClient.WithHoldingTaxPercentage,
                CurrencyCode = eClient.CurrencyCode,
                Name = eClient.Name

            };
            return returnClient;
        }

        private List<Client> Client(List<EClient> eClient)
        {
            var returnClient = eClient.Select(a => new Client

            {
                Code = a.Code,
                email1 = a.email1,
                email2 = a.email2,
                email3 = a.email3,
                Registration = a.Registration,

                ClientId = a.ClientId,
                CompanyId = a.CompanyId,
                RegistrationNumber = a.RegistrationNumber,
                Address = a.Address,
                Name = a.Name,
                TaxTypeId = a.TaxTypeId,
          //      TaxType1 = a.TaxType1,
                WithHoldingTaxPercentage = a.WithHoldingTaxPercentage,
                CurrencyCode = a.CurrencyCode
            });

            return returnClient.ToList();
        }

       
        #endregion
    }
}
