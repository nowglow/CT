using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT.Model;
namespace CT.UI.ViewModel
{
    public class Info_VideoViewModel
    {
        public IEnumerable<Video> Video1 { get; set; }
        public IEnumerable<Video> Video2 { get; set; }
        public IEnumerable<Video> Video3 { get; set; }
        public IEnumerable<Video> Video4 { get; set; }
    }
}