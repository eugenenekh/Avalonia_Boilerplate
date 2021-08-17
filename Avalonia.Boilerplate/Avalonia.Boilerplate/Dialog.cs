using Avalonia.Controls;
using Avalonia.Layout;

namespace Avalonia.Boilerplate {
    public class Dialog: Window {

        public Dialog() {
            ShowInTaskbar = false;
            SystemDecorations = SystemDecorations.BorderOnly;
            SizeToContent = SizeToContent.WidthAndHeight;
            VerticalContentAlignment = VerticalAlignment.Top;
            HorizontalContentAlignment = HorizontalAlignment.Left;
            MinHeight = 1;
            MinWidth = 1;
        }
    }
}