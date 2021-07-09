using System.Collections;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {
        private ContextMenu contextMenu;

        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            AddHandler(PointerReleasedEvent, MouseUpHandler, handledEventsToo: true);
        }

        private void MouseUpHandler(object? sender, PointerReleasedEventArgs e)
        {
            contextMenu?.Close();
            contextMenu = null;
            
            if (e.InitialPressMouseButton == MouseButton.Left)
            {
                return;
            } 
            
            contextMenu = new ContextMenu();
            contextMenu.Items = new ArrayList
            {
                new ItemsControl() { Name = "entry 1" }
            };

            contextMenu.Open(this);
        }
        
        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
