using CT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT.IDAL
{
    public interface IVideoClass : IBase<VideoClass>
    {
        VideoClass SelectID(int id);
        int DeleteID(int id);
    }
}
