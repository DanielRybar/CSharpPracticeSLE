using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _11ArchitekturyNET.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged; // udalost, ktera se spusti, pokud se zmeni stav, kdy se muze command spustit

        private Action _execute;
        private Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) // muze se spustit? (kdyz ne, tlacitko je zablokovane)
        {
            return _canExecute == null
                    ? true // pokud ho v commandu nezadame, tak je povoleno vždy
                    : _canExecute(); // jinak se spusti funkce, ktera nam vrati true/false
        }

        public void Execute(object? parameter) // spusti se pri stisku tlacitka
        {
            _execute();
        }

        public void RaiseCanExecuteChanged() // zavola se, pokud se zmeni stav, kdy se muze command spustit
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            // invoke znamena
            // if (CanExecuteChanged != null)
            // {
            //     CanExecuteChanged(this, EventArgs.Empty);
            // }

        }
    }
}
