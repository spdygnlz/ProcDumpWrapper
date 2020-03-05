using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using ProcDumpWrapper.Options;

namespace ProcDumpWrapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _output;
        private Process p = null;
        public IList<Option> Options { get; set; }

        public Dictionary<Group, IEnumerable<Option>> GroupedOptions { get; set; }

        public bool CanCancel
        {
            get
            {
                if (p != null && !p.HasExited)
                {
                    return true;
                }

                return false;
            }
        }

        public string CurrentCommandLine
        {
            get
            {
                var commandLineArgs = string.Join(" ", Options.Where(o => o.Enabled && o.Available)
                    .OrderBy(o => o.Order)
                    .Select(o => o.GetArguments()));

                return $"Procdump.exe {commandLineArgs}";
            }
        }

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            DataContext = this;

            var assembly = typeof(Option).Assembly;
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Option))).OrderBy(t => t.FullName);
            Options = types.Select(t => (Option)Activator.CreateInstance(t)).ToList();
            var groupTypes = assembly.GetTypes().Where(t => typeof(Group).IsAssignableFrom(t) && t.IsAbstract == false && t.IsInterface == false);
            GroupedOptions = groupTypes
                .Select(t => (Group) Activator.CreateInstance(t))
                .OrderBy(t => t.SortOrder)
                .ToDictionary(
                    x => x, 
                    x=> Options.Where(o => o.GroupType == x.GetType()));

            foreach (var option in Options)
            {
                option.EnabledChanged += Option_EnabledChanged;
                option.OptionsChanged += OptionsChanged;
            }

            foreach (var option in Options.Where(o => o.Enabled))
            {
                Option_EnabledChanged(option, new EnabledChangedEventArgs(option.Enabled, option.ConflictingTypes));
            }

            InitializeComponent();
        }

        private void OptionsChanged(object sender, OptionsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CurrentCommandLine));
        }

        private void Option_EnabledChanged(object sender, EnabledChangedEventArgs e)
        {
            foreach (var type in e.DisallowedOptions)
            {
                foreach (var option in Options.Where(o => o.GetType() == type))
                {
                    if (e.EnabledValue)
                    {
                        option.EnabledConflictingTypes.Add(sender.GetType());
                    }
                    else
                    {
                        option.EnabledConflictingTypes.Remove(sender.GetType());
                    }
                }
            }

            OnPropertyChanged(nameof(CurrentCommandLine));
        }

        private void RunProcDump(object sender, RoutedEventArgs e)
        {
            
            var commandLineArgs = string.Join(" ", Options.Where(o => o.Enabled && o.Available)
                                                            .OrderBy(o => o.Order)
                                                            .Select(o => o.GetArguments()));

            if (p != null && !p.HasExited)
            {
                Output += $"Process is already running.  Stop the current process and try again.{Environment.NewLine}";
                return;
            }

            Output += $"Full command: 'Procdump.exe {commandLineArgs}'{Environment.NewLine}";

            p = new Process
            {
                StartInfo = new ProcessStartInfo("Procdump.exe")
                {
                    Arguments = commandLineArgs, 
                    CreateNoWindow = true, 
                    RedirectStandardOutput = true, 
                    UseShellExecute = false
                }
            };

            p.EnableRaisingEvents = true;
            p.OutputDataReceived += P_OutputDataReceived;
            p.Exited += ProcessExited;
            p?.Start();
            p?.BeginOutputReadLine();
            OnPropertyChanged(nameof(CanCancel));
        }

        private void ProcessExited(object sender, EventArgs e)
        {
            CleanProcess();
        }

        private void CleanProcess()
        {
            if (p != null)
            {
                p.OutputDataReceived -= P_OutputDataReceived;
                p.Exited -= ProcessExited;
                p.Dispose();
                p = null;
            }

            OnPropertyChanged(nameof(CanCancel));
        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Output += $"{e.Data}{Environment.NewLine}";
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as Grid;
            if (grid.DataContext is Option option)
            {
                var customProps = option.GetCustomProperties();
                foreach (var prop in customProps)
                {
                    var stackPanel = grid.Children.OfType<StackPanel>().FirstOrDefault();
                    if (stackPanel == null) continue;

                    StackPanel optionContainer = new StackPanel() {Orientation = Orientation.Horizontal};
                    TextBlock title = new TextBlock
                    {
                        Text = prop.Name, 
                        Margin = new Thickness(10, 0, 10, 0), 
                        FontStyle = FontStyles.Italic
                    };

                    if (prop.PropertyType == typeof(int))
                    {
                        TextBox inputBox = new TextBox() {Width = 30};
                        Binding b = new Binding(prop.Name);
                        inputBox.SetBinding(TextBox.TextProperty, b);

                        Binding enabled = new Binding("Available");
                        inputBox.SetBinding(IsEnabledProperty, enabled);

                        optionContainer.Children.Add(title);
                        optionContainer.Children.Add(inputBox);

                        stackPanel.Children.Add(optionContainer);
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        TextBox inputBox = new TextBox() {Width = 75};
                        Binding b = new Binding(prop.Name);
                        inputBox.SetBinding(TextBox.TextProperty, b);

                        Binding enabled = new Binding("Available");
                        inputBox.SetBinding(IsEnabledProperty, enabled);

                        optionContainer.Children.Add(title);
                        optionContainer.Children.Add(inputBox);

                        stackPanel.Children.Add(optionContainer);
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        CheckBox inputBox = new CheckBox();
                        Binding b = new Binding(prop.Name);
                        inputBox.SetBinding(ToggleButton.IsCheckedProperty, b);

                        Binding enabled = new Binding("Available");
                        inputBox.SetBinding(IsEnabledProperty, enabled);

                        optionContainer.Children.Add(title);
                        optionContainer.Children.Add(inputBox);

                        stackPanel.Children.Add(optionContainer);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClearOutput(object sender, RoutedEventArgs e)
        {
            Output = string.Empty;
        }

        private void CancelRunningProcess(object sender, RoutedEventArgs e)
        {
            if (!p.HasExited)
            {
                p?.Kill();
                CleanProcess();
                Output += $"Process has been canceled. {Environment.NewLine}";
            }
        }
    }


    /*
    usage: procdump 
    1  [-a]
    10 [ [-c | -cl CPU usage] [-u] [-s seconds] ] 
    20 [-n exceeds] 
    30 [-e [1 [-b] ] [-f<filter,...>] ] 
    40 [-g] 
    50 [-h] 
    60 [-l] 
    70 [-m|-ml commit usage] 
    80 [-ma | -mp] 
    90 [-o] 
    100 [-p|-pl counter threshold] 
    110 [-r] 
    120 [-t] 
    130 [-d<callback DLL>] 
    140 [-64] 
    150 [-w] <process name or service name or PID> 
    160 [dump file] | -i<dump file> | 
    170 -u | 
    180 -x<dump file> <image file> [arguments] >] 
    190 [-? [ -e]
    */


    /*
     procdump.exe 
                [-mm] [-ma] [-mp] [-mc Mask] [-md Callback_DLL] [-mk]
                [-n Count]
                [-s Seconds]
                [-c|-cl CPU_Usage [-u]]
                [-m|-ml Commit_Usage]
                [-p|-pl Counter_Threshold]
                [-h]
                [-e [1 [-g] [-b]]]
                [-l]
                [-t]
                [-f  Include_Filter, ...]
                [-fx Exclude_Filter, ...]
                [-o]
                [-r [1..5] [-a]]
                [-wer]
                [-64]
                {
                 {{[-w] Process_Name | Service_Name | PID} [Dump_File | Dump_Folder]}
                |
                 {-x Dump_Folder Image_File [Argument, ...]}
                }

     */
}

