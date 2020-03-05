using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProcDumpWrapper
{
    public class TextBoxScrollBehavior
    {
        static readonly Dictionary<TextBox, Capture> _associations = 
            new Dictionary<TextBox, Capture>();

        public static bool GetScrollOnTextChanged(DependencyObject dependencyObject)
        {
            return (bool) dependencyObject.GetValue(ScrollOnTextChangedProperty);
        }

        public static void SetScrollOnTextChanged(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(ScrollOnTextChangedProperty, value);
        }

        public static readonly DependencyProperty ScrollOnTextChangedProperty = 
            DependencyProperty.RegisterAttached("ScrollOnTextChanged", typeof(bool), typeof(TextBoxScrollBehavior), new UIPropertyMetadata(false, OnScrollOnTextChanged));

        static void OnScrollOnTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var textBox = dependencyObject as TextBox;
            if (textBox == null)
            {
                return;
            }
            bool oldValue = (bool)e.OldValue, newValue = (bool)e.NewValue;
            if (newValue == oldValue)
            {
                return;
            }
            if (newValue)
            {
                textBox.Loaded += TextBoxLoaded;
                textBox.Unloaded += TextBoxUnloaded;
            }
            else
            {
                textBox.Loaded -= TextBoxLoaded;
                textBox.Unloaded -= TextBoxUnloaded;
                if (_associations.ContainsKey(textBox))
                {
                    _associations[textBox].Dispose();
                }
            }
        }

        static void TextBoxUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var textBox = (TextBox)sender;
            _associations[textBox].Dispose();
            textBox.Unloaded -= TextBoxUnloaded;
        }

        static void TextBoxLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var textBox = (TextBox)sender;
            textBox.Loaded -= TextBoxLoaded;
            _associations[textBox] = new Capture(textBox);
        }
    }

    public class Capture : IDisposable
    {
        private TextBox TextBox { get; set; }

        public Capture(TextBox textBox)
        {
            TextBox = textBox;
            TextBox.TextChanged += OnTextBoxChanged;
        }

        private void OnTextBoxChanged(object sender, TextChangedEventArgs e)
        {
            TextBox.ScrollToEnd();
        }

        #region IDispose Pattern

        // Flag: Has Dispose already been called?
        bool _disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool calledFromDotNet)
        {
            if (_disposed)
                return;

            if (calledFromDotNet)
            {
                TextBox.TextChanged -= OnTextBoxChanged;
            }

            // Free any unmanaged objects here.
            //
            _disposed = true;
        }

        #endregion
    }
}
