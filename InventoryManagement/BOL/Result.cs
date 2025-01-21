using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Result<T> : BaseResult
    {
        public T Data { get; set; }
    }

    public class ListResult<T> : BaseResult
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
    }
}
