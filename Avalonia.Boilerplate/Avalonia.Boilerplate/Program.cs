using System;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Win32;

namespace Avalonia.Boilerplate {
    class Program {

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) {

            //Add to Windows registry
            try {
                AddToRegistry();
            } catch(Exception e) {
                Console.WriteLine(e);
            }

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .With(new ClassicDesktopStyleApplicationLifetimeOptions() { ProcessUrlActivationCommandLine = true })
                .LogToTrace();

        private static void AddToRegistry() {

#pragma warning disable CA1416 // Validate platform compatibility
            RegistryKey existingKey = Registry.ClassesRoot.OpenSubKey("AvaloniaBoilerplate", true);
            if (existingKey != null) {
                return;
            }

            RegistryKey key = Registry.ClassesRoot.CreateSubKey("AvaloniaBoilerplate");
            key.SetValue("", "URL:AvaloniaBoilerplate Protocol");
            key.SetValue("URL Protocol", "");

            key.CreateSubKey("shell");
            key = key.OpenSubKey("shell", true);

            key?.CreateSubKey("open");
            key = key.OpenSubKey("open", true);

            key?.CreateSubKey("command");
            key = key.OpenSubKey("command", true);

            var exeDir = AppDomain.CurrentDomain.BaseDirectory + "Avalonia.Boilerplate.exe";
            key?.SetValue("", $"\"{exeDir}\" \"%1\"");
#pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}
