using System;
using System.Windows.Input;

namespace StartApp
{
    public class AddNameCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        Model parent;

        public AddNameCommand(Model parent)
        {
            this.parent = parent;
            parent.PropertyChanged += delegate { CanExecuteChanged?.Invoke(this, EventArgs.Empty); };
        }

        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(parent.CurrentName);
        }

        public void Execute(object? parameter)
        {
            parent.AddedNames.Add(parent.CurrentName);
            parent.CurrentName = null;
        }
    }
}
