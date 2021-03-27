using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API
{
    public class EreceiptClient
    {
        private string accessToken;
        private int id;
        private Token token;
        private IGroupService groupService;
        private IIdentityService identityService;
        private IUserService userService;
        private IReceiptService receiptService;


        public EreceiptClient(string token, IGroupService groupService,
            IIdentityService identityService,
            IUserService userService,
            IReceiptService receiptService)
        {
            accessToken = token;
            this.groupService = groupService;
            this.identityService = identityService;
            this.userService = userService;
            this.receiptService = receiptService;
        }

        public EreceiptClient(string token = "") : this(token, new GroupService(), new IdentityService(), new UserService(), new ReceiptService())
        {

        }

        public IGroupService GroupService => groupService;
        public IIdentityService IdentityService => identityService;
        public IUserService UserService => userService;
        public IReceiptService ReceiptService => receiptService;
        public void AuthorizeUser(Token token)
        {
            this.token = token;
            accessToken = token.AccessToken;
            groupService = new GroupService(accessToken);
            receiptService = new ReceiptService(accessToken);
            userService = new UserService(accessToken);
        }

        public string Token => token.AccessToken;
    }
}