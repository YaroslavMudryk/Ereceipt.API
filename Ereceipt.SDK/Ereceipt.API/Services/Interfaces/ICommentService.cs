using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(CommentCreateModel model);
        Task<Comment> EditCommentAsync(CommentEditModel model);
        Task<Comment> RemoveCommentAsync(long id);
        Task<Comment> GetCommentByIdAsync(long id);
    }
}