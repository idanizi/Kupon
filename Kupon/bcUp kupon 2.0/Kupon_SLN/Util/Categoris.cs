using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Categoris
    {
  
        public static List<string> getList()
        {
           List<string> list = new List<string>(){
                                    "Food",
                                    "Sports",
                                    "lifeStile",
                                    "Electronics",
                                    "fashion",
                                    "Games",
                                    "Books",
                                    "Other",
                                    "All"
                                 };
           return list;
           
        }
    }

    }

