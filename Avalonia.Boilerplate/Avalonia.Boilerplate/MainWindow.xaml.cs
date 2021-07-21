using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            OpenChild();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public void OpenChild() {
            var child = new ChildWindow();
            child.Show();
        }
    }
}
