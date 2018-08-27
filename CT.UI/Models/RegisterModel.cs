using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "用户头像")]
        public string User_Img { get; set; }

        [Required]
        [Display(Name = "用户名")]
        public string User_Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0}必须至少包含{2}个字符")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string User_Password { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "邮件格式不正确")]
        public string User_Email { get; set; }

        [Required]
        [Display(Name = "电话")]
        public string User_Phone { get; set; }
    }
}