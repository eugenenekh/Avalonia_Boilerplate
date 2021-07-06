using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
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

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            var w = new Window();
            var w2 = new Window();
            w2.Title = "w2";
            w2.MinWidth = 200;
            w2.MinHeight = 200;
            w2.Show();
            w2.Hide();
            w.Title = "w";
            w.Show(w2);
            
        }
    }
}
