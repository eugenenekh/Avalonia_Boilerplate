using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        protected override async Task<bool> CanClose()
        {
            await base.CanClose();
            return true;
        }
    }
}
