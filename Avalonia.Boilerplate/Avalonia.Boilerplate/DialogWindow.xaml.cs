using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class DialogWindow : Window {
        public DialogWindow() {
            InitializeComponent();
        }

        public Task<bool> ShowModalWindow(Window owner) {
            return ShowDialog<bool>(owner);
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            Width = 300;
            Height = 300;
        }
    }
}
