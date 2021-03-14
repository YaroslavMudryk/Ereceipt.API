using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.API.Models.Helpers
{
    public class CreateGroupModel
    {
        [Required, MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(2), MaxLength(25)]
        public string Color { get; set; }
        [MinLength(10), MaxLength(250)]
        public string Desc { get; set; }

        public CreateGroupModel(string name)
        {
            Name = name;
        }

        public CreateGroupModel(string name, string color, string desc)
        {
            Name = name;
            Color = color;
            Desc = desc;
        }
    }
}
