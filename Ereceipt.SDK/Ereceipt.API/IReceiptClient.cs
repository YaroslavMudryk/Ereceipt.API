using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using System.Threading.Tasks;

namespace Ereceipt.API
{
    public interface IReceiptClient
    {
        Task LoginAsync(LoginUserModel model);
        Task RegisterAsync(RegisterUserModel model);
        public string Token { get; }
        IGroupService GroupService { get; }
        IUserService UserService { get; }
        IReceiptService ReceiptService { get; }
        ICommentService CommentService { get; }
        ICurrencyService CurrencyService { get; }
        public string Version { get; }
    }
}