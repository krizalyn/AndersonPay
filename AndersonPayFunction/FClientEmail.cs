using System;
using System.Collections.Generic;
using System.Linq;
using AndersonPayData;
using AndersonPayModel;
using AndersonPayEntity;

namespace AndersonPayFunction
{
    public class FClientEmail : IFClientEmail
    {
        private IDClientEmail _iDClientEmail;

        public FClientEmail(IDClientEmail iDClientEmail)
        {
            _iDClientEmail = iDClientEmail;
        }

        public FClientEmail()
        {
            _iDClientEmail = new DClientEmail();
        }

        #region CREATE
        public ClientEmail Create(ClientEmail clientEmail)
        {
            EClientEmail eClientEmail = EClientEmail(clientEmail);
            eClientEmail = _iDClientEmail.Create(eClientEmail);
            return ClientEmail(eClientEmail);
        }
        #endregion

        #region READ
        public ClientEmail Read(int emailId)
        {
            EClientEmail eClientEmail = _iDClientEmail.Read<EClientEmail>(a => a.EmailId == emailId);
            return ClientEmail(eClientEmail);
        }

        public List<ClientEmail> Read()
        {
            List<EClientEmail> eClientEmail = _iDClientEmail.List<EClientEmail>(a => true);
            return ClientEmail(eClientEmail);
        }
        #endregion

        #region UPDATE
        public ClientEmail Update(ClientEmail clientEmail)
        {
            var eClientEmail = _iDClientEmail.Update(EClientEmail(clientEmail));
            return (ClientEmail(eClientEmail));
        }
        #endregion

        #region DELETE
        public void Delete(ClientEmail clientEmail)
        {
            _iDClientEmail.Delete(EClientEmail(clientEmail));
        }
        #endregion

        #region OTHER FUNCTION
        private EClientEmail EClientEmail(ClientEmail clientEmail)
        {
            EClientEmail returnEClientEmail = new EClientEmail
            {
                EmailId = clientEmail.EmailId,
                EmailAddress = clientEmail.EmailAddress
            };

            return returnEClientEmail;
        }

        private ClientEmail ClientEmail(EClientEmail eClientEmail)
        {
            ClientEmail returnClientEmail = new ClientEmail
            {
                EmailId = eClientEmail.EmailId,
                EmailAddress = eClientEmail.EmailAddress
            };
            return returnClientEmail;
        }

        private List<ClientEmail> ClientEmail(List<EClientEmail> eClientEmail)
        {
            var returnClientEmail = eClientEmail.Select(a => new ClientEmail
            {
                EmailId = a.EmailId,
                EmailAddress = a.EmailAddress
            });

            return returnClientEmail.ToList();
        }


        #endregion
    }
}
