using Ereceipt.API.Exceptions;
using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
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
        private ICommentService commentService;
        private ICurrencyService currencyService;


        public EreceiptClient(string token, IGroupService groupService,
            IUserService userService,
            IReceiptService receiptService,
            ICommentService commentService,
            ICurrencyService currencyService)
        {
            accessToken = token;
            this.groupService = groupService;
            this.userService = userService;
            this.receiptService = receiptService;
            this.commentService = commentService;
            this.currencyService = currencyService;
            urls = new BaseUrl();
            webRequest = new WebRequest(urls.Identity);
        }

        public EreceiptClient(string token) : this(token, new GroupService(token), new UserService(token), new ReceiptService(token), new CommentService(token), new CurrencyService(token))
        {}

        public EreceiptClient() : this(null, new GroupService(), new UserService(), new ReceiptService(), new CommentService(), new CurrencyService())
        {}

        public IGroupService GroupService => groupService;
        public IUserService UserService => userService;
        public IReceiptService ReceiptService => receiptService;
        public ICommentService CommentService => commentService;
        public ICurrencyService CurrencyService => currencyService;
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
            commentService = new CommentService(token);
            currencyService = new CurrencyService(token);
        }

        public string Token => token.AccessToken;
    }
}