using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using WebViewControl;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {

        private WebView view;

        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public void OpenChild() {
            var child = new ChildWindow();
            child.WindowStartupLocation = WindowStartupLocation.Manual;
            child.Position = new PixelPoint(0, 0);
            child.Height = 250;
            child.Width = 500;

            child.Show(this);
        }

        protected override void OnInitialized() {
            base.OnInitialized();
        }

        protected override void OnOpened(EventArgs e) {
            base.OnOpened(e);

            InitializeBrowser();
            OpenChild();
        }

        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e) {
            base.OnAttachedToLogicalTree(e);
        }

        private void InitializeBrowser() {
            var viewWrapper = this.FindControl<Decorator>("browserWrapper");
            view = new WebView();;

            view.Address = "https://wwww.google.com";
            viewWrapper.Child = view;
        }
    }
}
