using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            ExtendClientAreaTitleBarHeightHint = WindowDecorationMargin.Top;
        }

        private void OnOpenDialogNativeMenuItemClick(object sender, EventArgs e) {
            new DialogWindow().ShowModalWindow(this);
        }

        private void OnOpenDialogMenuItemClick(object sender, RoutedEventArgs e) {
            var dialog = new DialogWindow() { Width = 200, Height = 200 };
            dialog.ShowModalWindow(this);
            Console.WriteLine($"Dialog Width: {dialog.Width}, Dialog Height: {dialog.Height}");
        }
    }
}
