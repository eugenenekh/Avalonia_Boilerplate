using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

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

        public override bool CanClose()
        {
            return this.FindControl<CheckBox>("canClose").IsChecked == true && base.CanClose();
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            var dialog = new DialogWindow();
            dialog.Show(this);
        }
    }
}
