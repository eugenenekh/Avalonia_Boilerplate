using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace Avalonia.Boilerplate
{
    public class BaseWindow : Window
    {
        protected override bool HandleClosing()
        {
            var task = CanClose();
            task.Wait();
            if (task.Result)
            {
                return base.HandleClosing();
            }
            return true;
        }

        public virtual async Task<bool> CanClose()
        {
            var windows = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).Windows;
            var childrenWindows = windows.Where(x => x.Owner == this).ToList();
            var canBeClosed = true;
            foreach(var child in childrenWindows)
            {
                if (!await ((BaseWindow)child).CanClose())
                {
                    canBeClosed = false;
                }
            }
            return childrenWindows.Count == 0 || canBeClosed;
        }
    }
}