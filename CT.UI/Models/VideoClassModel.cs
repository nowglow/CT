using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class VideoClassModel
    {
        [Required]
        [Display(Name = "分类名")]
        [StringLength(5, ErrorMessage = "分类名输入格式错误（不能为空且长度不超过5）.")]
        public string Video_Class { get; set; }
    }
}