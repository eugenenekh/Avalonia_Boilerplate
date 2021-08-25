using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WebViewControl;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            WebView.Settings.OsrEnabled = false;

            var webview = new WebView();
            webview.Address = "https://google.com";

            this.Content = webview;
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
