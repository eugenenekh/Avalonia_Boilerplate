using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace Avalonia.Boilerplate
{
    public class BaseWindow : Window
    {
        protected override bool HandleClosing()
        {
            if (CanClose())
            {
                return base.HandleClosing();
            }
            return true;
        }

        public virtual bool CanClose()
        {
            var windows = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Windows;
            var childrenWindows = windows.Where(x => x.Owner == this).ToList();
            return childrenWindows.Count == 0 || !childrenWindows.Any(x => !((BaseWindow)x).CanClose());
        }
    }
}