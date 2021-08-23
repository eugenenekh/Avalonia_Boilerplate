using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Avalonia.Boilerplate {
    public class XamlDialogWindow : Window {

        public XamlDialogWindow() {

            // BorderBrush = Brushes.Red;
            // BorderThickness = new Thickness(10);
            // Width = 300;
            // Height = 100;
            // Content = new TextPresenter() {
            //     Text = "Hello xaml world!"
            // };


            // Background = Brushes.Aqua;
            // Padding = new Thickness(50);
            // Margin = new Thickness(50);
            // SystemDecorations = SystemDecorations.BorderOnly;
        }

        protected override void OnOpened(EventArgs e) {
            this.Activate();
        }
    }
}