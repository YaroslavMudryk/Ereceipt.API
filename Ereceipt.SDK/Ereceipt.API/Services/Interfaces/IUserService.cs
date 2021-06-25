using Ereceipt.API.Models;
using Ereceipt.API.Models.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> EditUserAsync(UserEditModel model);
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsers(int afterId = 0);
        Task<List<User>> SearchUsersAsync(string name, int afterId = 0);
    }
}