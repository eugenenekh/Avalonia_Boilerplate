using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window
    {

        private static Window popup;
        
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void InputElement_OnPointerEnter(object? sender, PointerEventArgs e)
        {
            if (popup == null)
            {
                popup = new Window();
                popup.ShowActivated = false;
                popup.Width = 100;
                popup.Height = 100;
                popup.Content = "Tooltip";
            }
            popup.Position = new PixelPoint(Position.X + 10, Position.Y + 20);
            popup.Show(this);
        }

        private void InputElement_OnPointerLeave(object? sender, PointerEventArgs e)
        {
            popup.Hide();
            popup.Show();
            popup.Hide();
        }
    }
}
