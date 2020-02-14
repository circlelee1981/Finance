using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Models.Users;
namespace Finance.Models
{
    /// <summary>
    /// Model的基类
    /// </summary>
    public abstract class BaseModel:IBaseModel
    {
        //[Required]
        public virtual int ID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateTime { get; set; }

        [Required]
        public bool IsRemoved { get; set; }


        [ForeignKey(nameof(User)),Required]
        public int UserID { get; set; }
        public User User { get; set; }


        [MaxLength(180)]
        public string Note { get; set; }

    }
}
