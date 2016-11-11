using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HanoiBusSystemManagement.Models
{
    public class ChangeImage
    {
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Yêu cầu nhập đường dẫn ảnh")]
        public string Img { get; set; }
    }
}