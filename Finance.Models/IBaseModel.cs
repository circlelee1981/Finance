using Finance.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Models
{
    public interface IBaseModel
    {
        //[Required]
        int ID { get; set; }
        DateTime CreateTime { get; set; }
        bool IsRemoved { get; set; }
        int UserID { get; set; }
        User User { get; set; }

        string Note { get; set; }

    }
}
