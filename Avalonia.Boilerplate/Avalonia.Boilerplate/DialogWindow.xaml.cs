using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace Avalonia.Boilerplate {
    public class DialogWindow : BaseWindow {
        public DialogWindow() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            Width = 300;
            Height = 300;
        }

        protected override async Task<bool> CanClose()
        {
            await base.CanClose();
            return await Dispatcher.UIThread.InvokeAsync(() => this.FindControl<CheckBox>("canClose").IsChecked) ?? false;
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            var dialog = new DialogWindow();
            dialog.Show(this);
        }
    }
}
