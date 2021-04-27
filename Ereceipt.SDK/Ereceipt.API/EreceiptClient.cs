using Ereceipt.API.Constants;
using Ereceipt.API.Exceptions;
using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System.IO;
using System.Threading.Tasks;
namespace Ereceipt.API
{
    public sealed class EreceiptClient : IReceiptClient
    {
        private string accessToken;
        private Token token;
        private WebRequest webRequest;
        private BaseUrl urls;
        private IGroupService groupService;
        private IUserService userService;
        private IReceiptService receiptService;


        public EreceiptClient(string token, IGroupService groupService,
            IUserService userService,
            IReceiptService receiptService)
        {
            accessToken = token;
            this.groupService = groupService;
            this.userService = userService;
            this.receiptService = receiptService;
            urls = new BaseUrl();
            webRequest = new WebRequest(urls.Identity);
        }

        public EreceiptClient(string token) : this(token, new GroupService(token), new UserService(token), new ReceiptService(token))
        {}

        public EreceiptClient() : this(null, new GroupService(), new UserService(), new ReceiptService())
        {}

        public IGroupService GroupService => groupService;
        public IUserService UserService => userService;
        public IReceiptService ReceiptService => receiptService;
        public void AuthorizeUser(Token token)
        {
            this.token = token;
            accessToken = token.AccessToken;
            InitServicesByToken(accessToken);
        }

        public async Task LoginAsync(LoginUserModel model)
        {
            var token = await webRequest.PostAsync<Token>("login", model);
            if (token.OK)
            {
                this.token = token.Data;
                InitServicesByToken(token.Data.AccessToken);
                return;
            }
            throw new AuthFailedException(token.ErrorMessage);
        }

        public async Task RegisterAsync(RegisterUserModel model)
        {
            var user = await webRequest.PostAsync<User>("register", model);
            if (user.OK)
            {
                await LoginAsync(new LoginUserModel(model.Login, model.Password));
            }
            throw new RegisterFailedException(user.ErrorMessage);
        }

        private void InitServicesByToken(string token)
        {
            groupService = new GroupService(token);
            receiptService = new ReceiptService(token);
            userService = new UserService(token);
        }

        public async Task SaveTokenAsync()
        {
            using var sw = new StreamWriter(TokenConstants.FullTokenPath);
            await sw.WriteLineAsync(accessToken);
        }

        public async Task GetTokenAsync()
        {
            using var sr = new StreamReader(TokenConstants.FullTokenPath);
            var content = await sr.ReadToEndAsync();
            accessToken = content ?? null;
        }

        public string Token => token.AccessToken;
    }
}