using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _03StrukturovaneDatoveTypy
{
    public class Zasobnik<T>
    {
        private T[] _array;
        private int _size;

        public int Count { get { return _array.Length; } } // počet prvků
        public int CountNotNull // počet prvků, které nejsou null
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public Zasobnik(int capacity)
        {
            if (capacity > 0)
            {
                _array = new T[capacity];
                _size = 0;
            }
            else
            {
                throw new InvalidCastException("Kapacita má být kladné číslo");
            }
        }

        public void Resize(int newSize)
        {
            T[] result = new T[newSize];
            for (int i = 0; i < result.Length; i++)
            {
                if (i < _array.Length) result[i] = _array[i];
            }
            _array = result;
        }

        public void Push(T element)
        {
            if (_size == _array.Length)
            {
                // Zásobník je plný, zvětšíme velikost pole
                // Resize(_array.Length * 2);

                // nebo vyhodíme výjimku
                throw new StackOverflowException("Přetekl zásobník prosim");
            }
            _array[_size++] = element;
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new TargetParameterCountException("Zásobník je prázdný");
            }
            T element = _array[--_size];
            _array[_size] = default(T); // uvolníme místo v poli pro Garbage Collector
            if (_size > 0 && _size == _array.Length / 4)
            {
                // Zásobník je poloprázdný, zmenšíme velikost pole
                Resize(_array.Length / 2);
            }
            return element;
        }

        public void Print()
        {
            Console.WriteLine("Obsah zásobníku:");
            for (int i = _size - 1; i >= 0; i--)
            {
                Console.WriteLine(_array[i]);
            }
        }
    }
}
