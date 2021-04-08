using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Layout;
using Avalonia.Threading;

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
        }

        private void OnOpenWindowClick(object sender, RoutedEventArgs e) {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                var popup = new PopuWindow();
                popup.ShowActivated = false;
                popup.Content = "BOOOOOOOOOOOOOOOOOM!";

                popup.Show();
            });
        }
    }

    internal class PopuWindow : Window
    {
        public PopuWindow()
        {
            ShowInTaskbar = false;
            SystemDecorations = SystemDecorations.BorderOnly;
            SizeToContent = SizeToContent.WidthAndHeight;
            VerticalContentAlignment = VerticalAlignment.Top;
            HorizontalContentAlignment = HorizontalAlignment.Left;

            // Displaying a Tooltip with dimensions 0x0 crashes on MacOS.
            // Since the tooltip data is obtained asynchronously the first render has a view with dimensions 0x0.
            // This workaround is needed while a new Avalonia version with the fix to https://github.com/AvaloniaUI/Avalonia/issues/5217 is not available.
            MinHeight = 1;
            MinWidth = 1;
        }
    }
}
