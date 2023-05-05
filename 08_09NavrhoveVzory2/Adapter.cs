using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09NavrhoveVzory2
{
    public interface IAnimalProcessor
    {
        void ProcessAnimalData(string data);
    }

    public class AnimalProcessor : IAnimalProcessor // třídu AnimalProcessor chceme použít v aplikaci, ve které se data bohužel předávají jako JSON
    {
        public void ProcessAnimalData(string data)
        {
            Console.WriteLine($"Processing animal data: {data}");
        }
    }

    // ----------------------------
    
    // aplikace s JSONEM
    public interface IJsonAnimalSource
    {
        string GetJsonData();
    }

    public class JsonAnimalSource : IJsonAnimalSource
    {
        public string GetJsonData()
        {
            return @"{
            'animals': [
                {
                    'name': 'Lion',
                    'age': 10,
                    'type': 'Mammal'
                },
                {
                    'name': 'Crocodile',
                    'age': 20,
                    'type': 'Reptile'
                }
            ]
        }";
        }
    }

    // vytvoříme adaptér, který bude implementovat stejné rozhraní jako AnimalProcessor a převede JSON na string
    public class JsonAnimalAdapter : IAnimalProcessor
    {
        private readonly IJsonAnimalSource _jsonSource;

        public JsonAnimalAdapter(IJsonAnimalSource jsonSource)
        {
            _jsonSource = jsonSource;
        }

        public void ProcessAnimalData(string data)
        {
            var jsonData = _jsonSource.GetJsonData();
            // parse the JSON data and extract animal data
            Console.WriteLine($"Processing animal data from JSON: {jsonData}");
        }
    }
}