using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForOfficialWorkProject.Helper
{
    public static class PathCheck
    {
        public static bool OpenOrClosed(in string? path) => File.Exists(path) ? true : false;
    }
}
