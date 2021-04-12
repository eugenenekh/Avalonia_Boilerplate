using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace Avalonia.Boilerplate {
    public class DialogWindow : BaseWindow
    {

        private static int i;
        
        public DialogWindow() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            Width = 300;
            Height = 300;
            Title = "Dialog " + ++i;
        }

        public override async Task<bool> CanClose()
        {
            var baseClose = await base.CanClose();
            return baseClose && this.FindControl<CheckBox>("canClose").IsChecked == true;
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            var dialog = new DialogWindow();
            dialog.Show(this);
        }
    }
}
