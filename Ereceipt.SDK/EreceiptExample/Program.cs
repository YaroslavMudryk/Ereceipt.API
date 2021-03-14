using Ereceipt.API;
using Ereceipt.API.Services;
using System;
using System.Threading.Tasks;

namespace EreceiptExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new EreceiptClient("", new GroupService(), new IdentityService(), new UserService(), new ReceiptService());
            var group = await client.GroupService.GetGroupByIdAsync(new Guid("4e762d73-8d82-47bb-26c0-08d8e6cf4c3d"));


        }
    }
}
