using Avalonia.Controls;
using Avalonia.VisualTree;

namespace Avalonia.Boilerplate {
    public class CustomToolTip {

        private readonly IControl content;
        private Dialog dialog;

        public CustomToolTip(IControl content) {
            this.content = content;
        }

        public void Show(IControl target) {
            Hide();
            if (target.GetVisualRoot() is Window parentWindow) {
                dialog = new Dialog();
                    dialog.ShowActivated = false;
                    dialog.Content = content;
                    dialog.Closing += delegate {
                        if (dialog != null) {
                            dialog.Content = null;
                        }
                    };
                    dialog.Closed += delegate { dialog = null; };
                    dialog.Show(parentWindow);
            }
        }

        public void Hide() {
            dialog?.Close();
        }
    }
}