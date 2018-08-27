using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class VideoCommentSupportModel
    {
        public int Video_ID { get; set; }

        public string Video_Title { get; set; }


        //视频评测支持的数量
        public int VideoSupportNum { get; set; }
    }
}