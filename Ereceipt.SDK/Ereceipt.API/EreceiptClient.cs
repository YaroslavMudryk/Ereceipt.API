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
        private string _accessToken;
        private string _version;
        private Token _token;
        private WebRequest _webRequest;
        private BaseUrl _urls;
        private IGroupService _groupService;
        private IUserService _userService;
        private IReceiptService _receiptService;
        private ICommentService _commentService;
        private ICurrencyService _currencyService;


        public EreceiptClient(string token, IGroupService groupService,
            IUserService userService,
            IReceiptService receiptService,
            ICommentService commentService,
            ICurrencyService currencyService)
        {
            _accessToken = token;
            _groupService = groupService;
            _userService = userService;
            _receiptService = receiptService;
            _commentService = commentService;
            _currencyService = currencyService;
            _urls = new BaseUrl();
            _webRequest = new WebRequest(_urls.Identity);
            _version = "0.9.0";
        }

        public EreceiptClient(string token) : this(token, new GroupService(token), new UserService(token), new ReceiptService(token), new CommentService(token), new CurrencyService(token))
        {}

        public EreceiptClient() : this(null, new GroupService(), new UserService(), new ReceiptService(), new CommentService(), new CurrencyService())
        {}

        public IGroupService GroupService => _groupService;
        public IUserService UserService => _userService;
        public IReceiptService ReceiptService => _receiptService;
        public ICommentService CommentService => _commentService;
        public ICurrencyService CurrencyService => _currencyService;
        public void AuthorizeUser(Token token)
        {
            _token = token;
            _accessToken = token.AccessToken;
            InitServicesByToken(_accessToken);
        }

        public async Task LoginAsync(LoginUserModel model)
        {
            var token = await _webRequest.PostAsync<Token>("login", model);
            if (token.OK)
            {
                AuthorizeUser(token.Data);
                return;
            }
            throw new AuthFailedException(token.ErrorMessage);
        }

        public async Task RegisterAsync(RegisterUserModel model)
        {
            var user = await _webRequest.PostAsync<User>("register", model);
            if (user.OK)
            {
                await LoginAsync(new LoginUserModel(model.Login, model.Password));
            }
            throw new RegisterFailedException(user.ErrorMessage);
        }

        private void InitServicesByToken(string token)
        {
            _groupService = new GroupService(token);
            _receiptService = new ReceiptService(token);
            _userService = new UserService(token);
            _commentService = new CommentService(token);
            _currencyService = new CurrencyService(token);
        }

        public string Token => _token.AccessToken;

        public string Version => _version;
    }
}