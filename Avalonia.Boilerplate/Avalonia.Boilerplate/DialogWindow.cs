using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Avalonia.Boilerplate {
    public class DialogWindow : Window {

        public DialogWindow() {
            Width = 100;
            Height = 50;
            Content = "Hello world!";

            Background = Brushes.Aqua;
            Padding = new Thickness(10);
        }
    }
}