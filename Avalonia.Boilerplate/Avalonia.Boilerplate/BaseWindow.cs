using System.ComponentModel;
using Avalonia.Controls;

namespace Avalonia.Boilerplate
{
    public class BaseWindow : Window
    {
        private bool isClosing;
        private bool isModal;
        
        public void ShowAsModal(Window parent)
        {
            isModal = true;
            Show(parent);
        }
        
        protected override bool HandleClosing()
        {
            isClosing = true;
            try
            {
                return base.HandleClosing();
            }
            finally
            {
                isClosing = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (isModal)
            {
                var owner = this;
                do
                {
                    owner = owner.Owner as BaseWindow;
                    if (owner?.isClosing == true)
                    {
                        // cancel bulk closing when this is a modal
                        e.Cancel = true;
                    }
                } while (owner != null);
            }
            base.OnClosing(e);
        }
    }
}