using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04bBinarniStrom
{
    class SlovnikoveHeslo : IComparable
    {
        public string Czech { get; set; }
        public string English { get; set; }

        public SlovnikoveHeslo(string cz, string en)
        {
            Czech = cz;
            English = en;
        }

        public int CompareTo(object? obj)
        {
            if (obj is SlovnikoveHeslo)
            {
                return Czech.CompareTo((obj as SlovnikoveHeslo).Czech);
            }
            else
                throw new ArgumentException("Nelze porovnat s objektem jiného typu.");
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}", Czech, English);
        }
    }
}
