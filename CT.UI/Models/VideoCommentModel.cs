using CT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class VideoCommentModel
    {
        //评论
        public List<VideoComment> VideoComment { get; set; }

        //二级评论
        public List<VideoCommentBack> VideoCommentBack { get; set; }
    }
}