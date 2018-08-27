using CT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT.UI.ViewModel
{
    public class InfoClassModel
    {
        public int InfoClass_ID { get; set; }
        public string Info_Class { get; set; }

        public virtual ICollection<Info> Info { get; set; }
        public virtual ICollection<ICC> ICC { get; set; }
    }
}