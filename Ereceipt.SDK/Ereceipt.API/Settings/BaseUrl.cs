using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Settings
{
    public class BaseUrl
    {
        private const string LocalHost = "https://localhost:5001/api/v1";

        private string groups;
        private string users;
        private string identity;
        private string receipts;

        public BaseUrl()
        {
            groups = $"{LocalHost}/groups";
            users = $"{LocalHost}/users";
            identity = $"{LocalHost}/identity";
            receipts = $"{LocalHost}/receipts";
        }
    }
}
