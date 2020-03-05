

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    public abstract class  Option : INotifyPropertyChanged
    {
        private bool _enabled;

        public event EventHandler<EnabledChangedEventArgs> EnabledChanged;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    var args = new EnabledChangedEventArgs( value, ConflictingTypes);
                    EnabledChanged?.Invoke(this, args);
                }
            }
        }

        public Option()
        {
            EnabledConflictingTypes.CollectionChanged += (s, e) => OnPropertyChanged(nameof(Available));
        }

        public abstract int Order { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }

        public virtual Type GroupType => typeof(MiscGroup);

        public virtual List<Type> ConflictingTypes { get; } = new List<Type>(){typeof(UninstallOption)};

        public ObservableCollection<Type> EnabledConflictingTypes { get; } = new ObservableCollection<Type>();

        public bool Available => !EnabledConflictingTypes.Any();

        public abstract string GetArguments();

        public IEnumerable<PropertyInfo> GetCustomProperties()
        {
            var props = GetType().GetProperties();
            return props.Where(p => 
                p.Name != nameof(Name) && 
                p.Name != nameof(Enabled) && 
                p.Name != nameof(Description) && 
                p.Name != nameof(Available) && 
                p.Name != nameof(Order));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<OptionsChangedEventArgs> OptionsChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnOptionsChanged(string newValue)
        {
            OptionsChanged?.Invoke(this, new OptionsChangedEventArgs(newValue));
        }
    }

    public class OptionsChangedEventArgs : EventArgs
    {
        public string Value { get; }

        public OptionsChangedEventArgs(string newValue)
        {
            Value = newValue;
        }
    }

    public class EnabledChangedEventArgs : EventArgs
    {
        public EnabledChangedEventArgs(bool newValue, List<Type> disallowedTypes)
        {
            EnabledValue = newValue;
            DisallowedOptions = disallowedTypes;
        }

        public IEnumerable<Type> DisallowedOptions { get; }
        public Type InitiatingType { get; }
        public bool EnabledValue { get; }
    }
}