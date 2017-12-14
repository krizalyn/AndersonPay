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
                email1 = client.email1,
                email2 = client.email2,
                email3 = client.email3,
                //email2 = client.email2,
                //email3 = client.email3,
                ClientId = client.ClientId,
                Code = client.Code,
                Address = client.Address,
                RegistrationNumber = client.RegistrationNumber,
                //Email1 = client.Email1,
                //Email2 = client.Email2,
                //Email3 = client.Email3,
                CompanyId = client.CompanyId,
                TaxTypeId = client.TaxTypeId,
            //    TaxType1 = client.TaxType1,
                Registration = client.Registration,

                Address = client.Address,
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
                Code = eClient.Code,
                Address = eClient.Address,
                RegistrationNumber = eClient.RegistrationNumber,
                //Email1 = eClient.Email1,
                //Email2 = eClient.Email2,
                //Email3 = eClient.Email3,
                CompanyId = eClient.CompanyId,
                TaxTypeId = eClient.TaxTypeId,
           //     TaxType1 = eClient.TaxType1,
                Address = eClient.Address,
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
                //email2 = a.email2,
                //email3 = a.email3,
                Registration = a.Registration,
                ClientId = a.ClientId,
                Code = a.Code,
                Address = a.Address,
                RegistrationNumber = a.RegistrationNumber,
                CompanyId = a.CompanyId,
                //Email1 = a.Email1,
                //Email2 = a.Email2,
                //Email3 = a.Email3,
                Name = a.Name,
                TaxTypeId = a.TaxTypeId,
          //      TaxType1 = a.TaxType1,
                Address = a.Address,
                WithHoldingTaxPercentage = a.WithHoldingTaxPercentage,
                CurrencyCode = a.CurrencyCode
            });

            return returnClient.ToList();
        }

       
        #endregion
    }
}
