using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif  
            this.FindControl<Button>("showCustomTooltip").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip0").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip0").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip1").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip1").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip2").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip2").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip3").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip3").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip4").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip4").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip5").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip5").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip6").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip6").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip7").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip7").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip8").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip8").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip9").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip9").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip10").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip10").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip11").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip1").PointerLeave += OnPointerLeave;
            this.FindControl<Button>("showCustomTooltip12").PointerEnter += OnPointerEnter;
            this.FindControl<Button>("showCustomTooltip12").PointerLeave += OnPointerLeave;
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            ExtendClientAreaTitleBarHeightHint = WindowDecorationMargin.Top;
        }

        private async void OnPointerEnter(object sender, PointerEventArgs args) {
            // this delay is to simulate view loading
            await Task.Delay(250);
            TooltipService.Show(this);
        }

        private void OnPointerLeave(object sender, PointerEventArgs args) {
            TooltipService.Hide();
        }
    }
}
