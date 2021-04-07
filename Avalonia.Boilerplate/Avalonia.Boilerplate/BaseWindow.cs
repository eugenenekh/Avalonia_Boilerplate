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
        private class RootClosingHandler : ClosingHandler
        {
            private readonly Dictionary<Window, ClosingHandler> closingHandlerByWindow = new Dictionary<Window, ClosingHandler>();

            public RootClosingHandler(Window owner, Func<Task<bool>> canClose) : base(owner, canClose)
            {
                AddClosingHandler(this);
            }

            public ClosingHandler GetClosingHandler(Window target)
            {
                closingHandlerByWindow.TryGetValue(target, out var closingHandler);
                return closingHandler;
            }
            
            public void AddClosingHandler(ClosingHandler closingHandler)
            {
                closingHandlerByWindow.Add(closingHandler.Target, closingHandler);
            }
            
            public static RootClosingHandler GetRootClosingHandler(Window window)
            {
                while (window.Owner is Window owner)
                {
                    window = owner;    
                }

                if (window is BaseWindow baseWindow)
                {
                    return baseWindow.closingHandler;
                }

                return null;
            }
        }
        

        private class ClosingHandler
        {
            private readonly List<ClosingHandler> children = new List<ClosingHandler>();
            private readonly Func<Task<bool>> canClose;
            
            public ClosingHandler(Window target, Func<Task<bool>> canClose)
            {
                Target = target;
                this.canClose = canClose ?? (() => Task.FromResult(true));
            }

            public Window Target { get; }
            public bool IsClosing { get; private set; }

            public void AddClosingChild(ClosingHandler handler)
            {
                if (!IsClosing)
                {
                    children.Add(handler);
                }
            }

            public async Task<bool> Close()
            {
                if (IsClosing)
                {
                    return false;
                }

                IsClosing = true;
                try
                {
                    var allChildrenClosed = true;
                    foreach (var closingHandler in children)
                    {
                        if (!await closingHandler.Close())
                        {
                            allChildrenClosed = false;
                        }
                    }

                    if (allChildrenClosed)
                    {
                        if (await canClose())
                        {
                            Target.Close();
                            return true;
                        }
                    }

                    return false;
                }
                finally
                {
                    IsClosing = false;
                }
            }
        }
        
        private RootClosingHandler closingHandler;
        
        protected override bool HandleClosing()
        {
            if (closingHandler != null)
            {
                // already closing, bail-out
                return true;
            }

            var result = false;
            closingHandler = new RootClosingHandler(this, CanClose);
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
                var rootClosingHandler = RootClosingHandler.GetRootClosingHandler(this);
                if (rootClosingHandler.IsClosing)
                {
                    return;
                }
                
                var closingHandler = rootClosingHandler.GetClosingHandler(this);
                if (closingHandler == null)
                {
                    closingHandler = new ClosingHandler(this, CanClose);
                    rootClosingHandler.AddClosingHandler(closingHandler);
                }

                var owner = Owner as Window;
                var parentClosingHandler = rootClosingHandler.GetClosingHandler(owner);
                if (parentClosingHandler == null)
                {
                    Func<Task<bool>> closingHandlerFunc = Owner is BaseWindow ownerBaseWindow ? ownerBaseWindow.CanClose : null;
                    parentClosingHandler = new ClosingHandler(owner, closingHandlerFunc);
                    rootClosingHandler.AddClosingHandler(parentClosingHandler);
                }

                parentClosingHandler.AddClosingChild(closingHandler);
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