using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncP
{
    public static class MyTools
    {
        public static int GetCode(this string name)
        {
            int rs = 0;
            for(int i = 0; i < name.Length; i++)
            {
                rs += (int)name[i];
            }

            return rs;
        }
    }
}
