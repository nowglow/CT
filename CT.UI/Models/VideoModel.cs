using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class VideoModel
    {
        public int Video_ID;
        [Required]
        [Display(Name = "标题")]
        [StringLength(25, ErrorMessage = "分类名输入格式错误（不能为空且长度不超过25）.")]
        public string Video_Title { get; set; }

        [Display(Name = "视频")]
        [Required(ErrorMessage = "请上传你的视频！")]
        public string Video_Url { get; set; }

        [Display(Name = "封面")]
        [Required(ErrorMessage = "请上传你的封面图片！")]
        public string Video_Img { get; set; }

        [Display(Name = "分类")]
        [Required(ErrorMessage = "请选择你的分类！")]
        public int VideoClass_ID { get; set; }

        [Required]
        [Display(Name = "时间")]
        public System.DateTime Video_Time { get; set; }

        //视频分类名
        public string Video_Class { get; set; }
    }
}