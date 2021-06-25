using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class CommentService : ICommentService
    {
        private WebRequest webRequest;
        private string basicRoute { get; }
        public CommentService(string accessToken = "")
        {
            webRequest = new WebRequest(accessToken, 10);
            basicRoute = ApiRoutes.V1.Comments.Basic;
        }


        public async Task<Comment> CreateCommentAsync(CommentCreateModel model)
        {
            var response = await webRequest.PostAsync<Comment>(basicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Comment> EditCommentAsync(CommentEditModel model)
        {
            var response = await webRequest.PutAsync<Comment>(basicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Comment> GetCommentByIdAsync(long id)
        {
            var response = await webRequest.GetAsync<Comment>($"{basicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Comment> RemoveCommentAsync(long id)
        {
            var response = await webRequest.DeleteAsync<Comment>($"{basicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}