using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03StrukturovaneDatoveTypy
{
    public class DataStore<T> // T značí datový typ - např. int, string
    {
        public DataStore(T data)
        {
            Data = data;
        }

        public T Data { get; set; } // stejný datový typ jako má třída
    }
}
