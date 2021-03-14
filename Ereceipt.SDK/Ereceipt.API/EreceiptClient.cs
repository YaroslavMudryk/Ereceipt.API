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
        private BaseUrl urls;

        private IGroupService groupService;
        private IIdentityService identityService;
        private IUserService userService;
        private IReceiptService receiptService;

        public EreceiptClient(string accessToken)
        {
            this.accessToken = accessToken;
            urls = new BaseUrl();
        }

        public EreceiptClient(IGroupService groupService, IIdentityService identityService, IUserService userService, IReceiptService receiptService)
        {
            this.groupService = groupService;
            this.identityService = identityService;
            this.userService = userService;
            this.receiptService = receiptService;
        }
    }
}