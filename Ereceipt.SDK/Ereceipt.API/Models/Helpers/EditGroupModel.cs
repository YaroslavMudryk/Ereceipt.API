using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Models.Helpers
{
    public class EditGroupModel : CreateGroupModel
    {
        public Guid Id { get; set; }
        public EditGroupModel(string name) : base(name)
        {

        }
        public EditGroupModel(Guid id, string name, string color, string desc) : base(name, color, desc)
        {
            Id = id;
        }
    }
}