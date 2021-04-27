using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Settings
{
    public class BaseUrl
    {
        private const string LocalHost = "https://localhost:5001/api/v1/";
        private const string ServerHost = "https://e-receipt.com/api/v1/";

        private string groupsUrl;
        private string usersUrl;
        private string identityUrl;
        private string receiptsUrl;

        public BaseUrl()
        {
            groupsUrl = $"{LocalHost}groups";
            usersUrl = $"{LocalHost}users";
            identityUrl = $"{LocalHost}identity";
            receiptsUrl = $"{LocalHost}receipts";
        }

        public string Group => groupsUrl;
        public string Users => usersUrl;
        public string Identity => identityUrl;
        public string Receipts => receiptsUrl;
    }
}
