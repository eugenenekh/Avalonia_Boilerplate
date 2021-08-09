using System;
using System.ComponentModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;

namespace Avalonia.Boilerplate {
    public class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new MainWindow();
            }
            var lifetimeEvents = AvaloniaLocator.Current.GetService<IPlatformLifetimeEventsImpl>();
            if (lifetimeEvents != null) {
                lifetimeEvents.ShutdownRequested += OnShutdownRequested;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void OnShutdownRequested(object sender, CancelEventArgs args) {
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    new DialogWindow().ShowModalWindow(desktop.MainWindow);
                }
            args.Cancel = true;
        }
    }
}
