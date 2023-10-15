using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINOTI.Helpers
{
    public class Pager<T> where T : class
    {
        public Pager()
        {
        }

        public string Search { get; set; }
        public int Pagesize { get; }
        public int Pageindex { get; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public List<T> Registros { get; private set; }
        
        public Pager(List<T> registros, string search, int pagesize, int pageindex, int total)
        {
            Registros = registros;
            Search = search;
            Pagesize = pagesize;
            Pageindex = pageindex;
            Total = total;
        }

        public int TotalPages{
            get { return (int)Math.Ceiling(Total / (double)PageSize);}
            set{ this.TotalPages = value;}
        }

        public bool HasPreviousPage{
            get { return (PageIndex > 1);}
            set { this.HasPreviousPage = value;}
        }

        public bool HasNextPage{
            get { return (PageIndex < TotalPages);}
            set { this.HasNextPage = value;}
        }
    }
}