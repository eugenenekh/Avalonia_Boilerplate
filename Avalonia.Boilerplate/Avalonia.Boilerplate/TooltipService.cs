using Avalonia.Controls;
using Avalonia.Controls.Presenters;

namespace Avalonia.Boilerplate {
      public class TooltipService {

        private static CustomToolTip customTooltip;

        public static void Show(IControl target) {
            if (customTooltip == null) {
                customTooltip = new CustomToolTip(new TextPresenter() {
                    Height = 30,
                    Width = 100,
                    Text = "Hello world!"
                });
            }
            customTooltip.Show(target);
        }

        public static void Hide() {
            customTooltip?.Hide();
        }
    }
}