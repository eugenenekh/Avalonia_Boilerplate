using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class DialogWindow : Window {

        private static WindowBase hiddenWindow;

        public DialogWindow() {
            InitializeComponent();
            GetHiddenWindow();
        }

        public Task<bool> ShowModalWindow(Window owner) {
            return ShowDialog<bool>(owner);
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            Width = 300;
            Height = 300;
        }

        private static WindowBase GetHiddenWindow() {
            if (hiddenWindow == null) {
                hiddenWindow = new Window() {
                    IsVisible = false,
                    Focusable = false,
                    Title = "Hidden React View Window"
                };
                hiddenWindow.Closed += new EventHandler(OnHiddenWindowClose);
            }            
            return hiddenWindow;
        }

        private static void OnHiddenWindowClose(object sender, EventArgs e) {
            return;
        }
    }
}
