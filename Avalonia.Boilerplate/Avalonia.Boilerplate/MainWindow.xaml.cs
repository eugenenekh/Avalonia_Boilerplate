using System;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class MainWindow : BaseWindow
    {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnOpenDialogNativeMenuItemClick(object sender, EventArgs e)
        {
            ShowDialog();
        }

        private void OnOpenDialogMenuItemClick(object sender, RoutedEventArgs e)
        {
            ShowDialog();
        }

        private void ShowDialog()
        {
            var dialog = new DialogWindow();
            dialog.Show(this);
        }
    }
}
