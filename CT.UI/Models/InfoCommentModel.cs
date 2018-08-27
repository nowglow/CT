using CT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT.UI.Models
{
    public class InfoCommentModel
    {
        //评论
        public List<InfoComment> InfoComment { get; set; }

        //二级评论
        public List<InfoCommentBack> InfoCommentBack { get; set; }
    }
}