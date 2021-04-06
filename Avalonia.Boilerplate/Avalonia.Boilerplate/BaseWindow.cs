using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace Avalonia.Boilerplate
{
    public class BaseWindow : Window
    {
        private class ClosingHandler
        {
            private readonly List<(BaseWindow, Func<Task<bool>>)> children = new List<(BaseWindow, Func<Task<bool>>)>();

            public ClosingHandler(BaseWindow owner, Func<Task<bool>> closingHandler)
            {
                AddClosingChild(owner, closingHandler);
            }
            
            public static ClosingHandler GetClosingHandler(BaseWindow window)
            {
                if (window == null)
                {
                    return null;
                }
                
                return window.closingHandler ?? GetClosingHandler(window.Owner as BaseWindow);
            }
            
            public bool IsClosing { get; private set; }

            public void AddClosingChild(BaseWindow window, Func<Task<bool>> closingHandler)
            {
                if (!IsClosing)
                {
                    children.Add((window, closingHandler));
                }
            }

            public async Task Close()
            {
                if (IsClosing)
                {
                    return;
                }

                IsClosing = true;
                try
                {
                    var allChildrenClosed = true;
                    // take children first
                    var sortedChildrenToClose = children.Skip(1);
                    foreach (var (child, closingHandler) in sortedChildrenToClose)
                    {
                        if (await closingHandler())
                        {
                            child.Close();
                        }
                        else
                        {
                            allChildrenClosed = false;
                        }
                    }

                    if (allChildrenClosed)
                    {
                        var (self, closingHandler) = children.First();
                        if (await closingHandler())
                        {
                            self.Close();
                        }
                    }
                }
                finally
                {
                    IsClosing = false;
                }
            }
        }
        
        private ClosingHandler closingHandler;

        protected override bool HandleClosing()
        {
            if (closingHandler != null)
            {
                // already closing
                return base.HandleClosing();
            }

            var result = false;
            closingHandler = new ClosingHandler(this, CanClose);
            try
            {
                result = base.HandleClosing();
            }
            catch
            {
                closingHandler = null;
                throw;
            }

            closingHandler.Close().ContinueWith(_ => closingHandler = null);
            return result;
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            if (closingHandler == null)
            {
                // closing self and not a parent closing a child
                ClosingHandler.GetClosingHandler(this)?.AddClosingChild(this, CanClose);
            }
            else
            {
                e.Cancel = !closingHandler.IsClosing;
            }
            base.OnClosing(e);
        }

        protected virtual async Task<bool> CanClose()
        {
            await Task.Delay(500);
            var result = false;
            return result;
        }
    }
}