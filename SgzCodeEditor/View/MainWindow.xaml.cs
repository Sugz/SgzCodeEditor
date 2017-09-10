using System;
using System.Windows;
using SgzCodeEditor.ViewModel;
using SugzTools.Icons;

namespace SgzCodeEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            switch (WindowState)
            {
                case WindowState.Minimized:
                case WindowState.Normal:
                    backgroundPanel.Margin = new Thickness(0);
                    break;
                case WindowState.Maximized:
                    backgroundPanel.Margin = new Thickness(8);
                    break;
            }
        }

        private void closeWindowBtn_Click(object sender, RoutedEventArgs e) => SystemCommands.CloseWindow(this);

        private void MaximizeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    MaximizeWindowBtn.Icon = Geo.MdiWindowRestore;
                    SystemCommands.MaximizeWindow(this);
                    break;
                case WindowState.Maximized:
                    MaximizeWindowBtn.Icon = Geo.MdiWindowMaximize;
                    SystemCommands.RestoreWindow(this);
                    break;
            }
        }

        private void minimizeWindowBtn_Click(object sender, RoutedEventArgs e) => SystemCommands.MinimizeWindow(this);
    }
}