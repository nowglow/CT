using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT.Model;
namespace CT.UI.ViewModel
{
    public class Info_IndexViewModel
    {
        public Info one { get; set; }
        public IEnumerable<Info> Gundongye { get; set; }
        public IEnumerable<Info> get5 { get; set; }
        public IEnumerable<Video> get3 { get; set; }

        public IEnumerable<ICC> ICC { get; set; }

        public IEnumerable<InfoClass> InfoClass { get; set; }

    }
}