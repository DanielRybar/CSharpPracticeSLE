using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09NavrhoveVzory2
{
    // v podstatě něco jako bankovní trezor - řešení jednotlivých stavů a přepínání mezi nimi

    // Rozhraní pro stav světelného přepínače
    public interface ILightState
    {
        void SwitchOn();
        void SwitchOff();
    }

    // Stav zapnutí světelného přepínače
    public class LightOnState : ILightState
    {
        public void SwitchOn()
        {
            Console.WriteLine("Light is already on");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Switching light off");
        }
    }

    // Stav vypnutí světelného přepínače
    public class LightOffState : ILightState
    {
        public void SwitchOn()
        {
            Console.WriteLine("Switching light on");
        }

        public void SwitchOff()
        {
            Console.WriteLine("Light is already off");
        }
    }

    // Světelný přepínač
    public class LightSwitch
    {
        private ILightState _state;

        public LightSwitch()
        {
            // Výchozí stav je vypnutý
            _state = new LightOffState();
        }

        public void SwitchOn()
        {
            _state.SwitchOn();
            _state = new LightOnState();
        }

        public void SwitchOff()
        {
            _state.SwitchOff();
            _state = new LightOffState();
        }
    }
}