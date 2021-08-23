using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // Content = new ItemsPresenter() {
            //     Items = new List<Button>() { OpenWindowButton(), CloseWindowButton() }
            // };
            Closed += delegate {window = null;};
        }

        private Button OpenWindowButton() {
            var btn = new Button();
            btn.Content = "Click to open a dialog window";
            btn.Click += OnOpenWindowClick;
            return btn;
        }

        private Button CloseWindowButton() {
            var btn = new Button();
            btn.Content = "Click to close a dialog window";
            btn.Click += OnCloseWindowClick;
            return btn;
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private XamlDialogWindow window;

        public void OnOpenWindowClick(object sender, RoutedEventArgs args) {
            if (window == null) {
                window = new XamlDialogWindow();
                window.ShowInTaskbar = false;
            }
            window.Show(this);
        }

        public void OnCloseWindowClick(object sender, RoutedEventArgs args) {
            window?.Close();
        }


    }
}
