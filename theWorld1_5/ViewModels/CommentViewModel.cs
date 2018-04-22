using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theWorld1_5.ViewModels
{
    public class CommentViewModel
    {

        [Required]
        [StringLength(130,MinimumLength =2)]
        public string Response { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
  
    }
}
