using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Settings
{
    public static class ApiRoutes
    {
        private const string ServerHost = "https://e-receipt.com";

        private const string LocalHost = "https://localhost:5001";

        private const string Root = "/api";

        public static class V1
        {
            public static class Users
            {
                public const string Basic = LocalHost + Root + "/v1" + "/users";
            }

            public static class Receipts
            {
                public const string Basic = LocalHost + Root + "/v1" + "/receipts";
            }

            public static class Comments
            {
                public const string Basic = LocalHost + Root + "/v1" + "/comments";
            }

            public static class Groups
            {
                public const string Basic = LocalHost + Root + "/v1" + "/groups";
            }

            public static class Identity
            {
                public const string Basic = LocalHost + Root + "/v1" + "/identity";
            }

            public static class Currencies
            {
                public const string Basic = LocalHost + Root + "/v1" + "/currencies";
            }
        }
    }
}
