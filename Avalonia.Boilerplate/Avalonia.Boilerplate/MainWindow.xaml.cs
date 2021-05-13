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

        private void OnShowDialogClick(object sender, RoutedEventArgs e) {
            new DialogWindow().ShowModalWindow(this);
        }
    }
}
