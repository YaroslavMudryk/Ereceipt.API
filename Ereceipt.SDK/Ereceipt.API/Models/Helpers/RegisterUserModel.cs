using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Models.Helpers
{
    public class RegisterUserModel : LoginUserModel
    {
        public string Name { get; set; }
        public RegisterUserModel(string name, string login, string password) : base(login, password)
        {
            Name = name;
        }
    }
}
