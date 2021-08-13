using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("showCustomTooltip").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showAnotherCustomTooltip").PointerEnter += OnPointerEnter1;
            this.FindControl<Button>("showAnotherCustomTooltip").PointerLeave += OnPointerLeave1;
        }

        public static void WindowStatePropertyChanged(AvaloniaPropertyChangedEventArgs<WindowState> args)
        {
            if (args.OldValue.GetValueOrDefault<WindowState>() == WindowState.Minimized)
            {
                ((Window)args.Sender).Renderer.Start();
            }
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            ExtendClientAreaTitleBarHeightHint = WindowDecorationMargin.Top;
        }

        private readonly CustomToolTip tooltip = new CustomToolTip(new TextPresenter() {
                Height = 200,
                Width = 200
            });

        private readonly CustomToolTip tooltip1 = new CustomToolTip(new TextPresenter() {
                Height = 300,
                Width = 300
            });

        private void OnPointerEnter(object sender, PointerEventArgs args) {
            tooltip.Show(this);
        }

        private void OnPointerLeave(object sender, PointerEventArgs args) {
            tooltip.Hide();
        }

        private void OnPointerEnter1(object sender, PointerEventArgs args) {
            tooltip1.Show(this);
        }

        private void OnPointerLeave1(object sender, PointerEventArgs args) {
            tooltip1.Hide();
        }
    }
}
