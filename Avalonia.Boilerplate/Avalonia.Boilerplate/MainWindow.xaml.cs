using System;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        protected override void OnClosing(CancelEventArgs e) {
            var windows = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Windows;
            e.Cancel |= windows.Any(w => w is DialogWindow);
            base.OnClosing(e);
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);

        }

        private void OnOpenDialogNativeMenuItemClick(object sender, EventArgs e) {
            new DialogWindow().ShowModalWindow(this);
        }

        private void OnOpenDialogMenuItemClick(object sender, RoutedEventArgs e) {
            new DialogWindow().ShowModalWindow(this);
        }
    }
}
