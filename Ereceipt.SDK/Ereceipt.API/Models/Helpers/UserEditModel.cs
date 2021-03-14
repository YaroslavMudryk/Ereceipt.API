using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.API.Models.Helpers
{
    public class UserEditModel
    {
        [Required, MinLength(5), MaxLength(150)]
        public string Name { get; set; }
        public int Id { get; set; }

        public UserEditModel(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}