using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class App : Application {

        public App() {
            UrlsOpened += (object sender, UrlOpenedEventArgs e) => {
                //System.Diagnostics.Debugger.Launch();
                var window = new MainWindow();
                window.Title = string.Join(",", e.Urls);
                window.Show();
            };
        }

        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
