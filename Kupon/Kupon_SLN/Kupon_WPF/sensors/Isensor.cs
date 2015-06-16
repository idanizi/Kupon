using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kupon_WPF
{
    interface Isensor
    {
        event EventHandler infoChanged;
        Object getInfo();



        void open();

        void close();

    }
}
