namespace Ereceipt.API.Settings
{
    public static class ApiRoutes
    {
        private const string Host = "https://localhost:5001"; // https://e-receipt.com
        private const string Root = "/api";
        public static class V1
        {
            public const string Version1 = "/v1";
            public static class Budgets
            {
                public const string Basic = Host + Root + Version1 + "/budgets";
            }
            public static class Users
            {
                public const string Basic = Host + Root + Version1 + "/users";
            }
            public static class Receipts
            {
                public const string Basic = Host + Root + Version1 + "/receipts";
            }
            public static class Comments
            {
                public const string Basic = Host + Root + Version1 + "/comments";
            }
            public static class Groups
            {
                public const string Basic = Host + Root + Version1 + "/groups";
            }
            public static class Identity
            {
                public const string Basic = Host + Root + Version1 + "/identity";
            }
            public static class Currencies
            {
                public const string Basic = Host + Root + Version1 + "/currencies";
            }
        }
    }
}