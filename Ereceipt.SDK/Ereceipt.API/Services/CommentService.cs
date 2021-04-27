using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using Ereceipt.API.Services.Interfaces;
using Ereceipt.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Services
{
    public class CommentService : ICommentService
    {
        private WebRequest webRequest;
        private BaseUrl urls;
        public string BasicRoute { get; }
        public CommentService(string accessToken = "")
        {
            urls = new BaseUrl();
            webRequest = new WebRequest(accessToken, 10);
            BasicRoute = ApiRoutes.V1.Comments.Basic;
        }


        public async Task<Comment> CreateCommentAsync(CommentCreateModel model)
        {
            var response = await webRequest.PostAsync<Comment>(BasicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Comment> EditCommentAsync(CommentEditModel model)
        {
            var response = await webRequest.PutAsync<Comment>(BasicRoute, model);
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Comment> GetCommentByIdAsync(long id)
        {
            var response = await webRequest.GetAsync<Comment>($"{BasicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }

        public async Task<Comment> RemoveCommentAsync(long id)
        {
            var response = await webRequest.DeleteAsync<Comment>($"{BasicRoute}/{id}");
            if (response.OK)
                return response.Data;
            return null;
        }
    }
}