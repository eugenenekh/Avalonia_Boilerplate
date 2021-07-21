using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace Avalonia.Boilerplate {
    public class ChildWindow : Window {
        public ChildWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            Padding = new Thickness(1,22,1,1);
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e) {
            base.OnApplyTemplate(e);
            var titleBar = this.FindDescendantOfType<TitleBar>();
            if (titleBar != null) {
                titleBar.IsVisible = false;
            }

            if (titleBar == null) {
                return;
            }

            titleBar.ApplyTemplate();
            var titleBorder = titleBar.FindDescendantOfType<Border>();
            if (titleBorder != null) {
                titleBorder.Child = new TextBlock() {
                    Name = "PART_TitleHolder",
                };
            }
        }
    }
}
