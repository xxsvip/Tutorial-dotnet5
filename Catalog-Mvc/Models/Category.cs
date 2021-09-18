using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Catalog_Mvc.Models
{
    public class Category
    {

        [Key]
        public int id { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名必须填写")]
        public string name { get; set; }

        [DisplayName("展示顺序")]
        [Range(1,int.MaxValue,ErrorMessage = "必须大于0")]
        public int display_order { get; set; }
        
        
        
        
    }
}