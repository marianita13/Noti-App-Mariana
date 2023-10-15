using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace APINOTI.Helpers
{
    public class Params
    {
        private int _PageSize = 5;
        private const int MaxPageSize = 50;
        private int _PageIndex = 1;
        private int _pageSize = 1;
        private string _search;

        public int PageSize{
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int PageIndex{
            get => _PageIndex;
            set => _PageIndex = (value <= 0)? 1 : value;
        }

        public string search{
            get => _search;
            set => _search = (!String.IsNullOrEmpty(value)) ? value.ToLower(): "";
        }
    }
}