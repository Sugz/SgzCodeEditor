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
        private double _OldTvWidth = 300;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            showTvBtn.Click += (s, e) => SetLayout();
            SetLayout();
        }


        #region TreeViews panel visibility

        /// <summary>
        /// Show or hide the treeviews
        /// </summary>
        private void SetLayout()
        {
            if (tvsPanel.ActualWidth == 0)
            {
                gridSplitter.Visibility = Visibility.Visible;
                layoutRoot.ColumnDefinitions[0].Width = new GridLength(_OldTvWidth);
            }
            else
            {
                gridSplitter.Visibility = Visibility.Collapsed;
                layoutRoot.ColumnDefinitions[0].Width = new GridLength(0);
            }

        }

        /// <summary>
        /// Store the treeviews panel ActualWidth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvsPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (tvsPanel.ActualWidth > 0)
                _OldTvWidth = tvsPanel.ActualWidth;
        } 

        #endregion TreeViews panel visibility


        #region Window State

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            switch (WindowState)
            {
                case WindowState.Minimized:
                case WindowState.Normal:
                    MaximizeWindowBtn.Icon = Geo.MdiWindowMaximize;
                    backgroundPanel.Margin = new Thickness(0);
                    break;
                case WindowState.Maximized:
                    MaximizeWindowBtn.Icon = Geo.MdiWindowRestore;
                    backgroundPanel.Margin = new Thickness(8);
                    break;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => SystemCommands.CloseWindow(this);

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    SystemCommands.MaximizeWindow(this);
                    break;
                case WindowState.Maximized:
                    SystemCommands.RestoreWindow(this);
                    break;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e) => SystemCommands.MinimizeWindow(this);


        #endregion Window State
    }
}