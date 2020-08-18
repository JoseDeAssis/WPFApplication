using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp.Themes {
    public class FloatingActionButton : Button {
        private static readonly string PART_ELLIPSE = "PART_Ellipse";
        private static readonly string PART_BODY = "PART_Body";

        private static readonly Brush _primaryColor = (Brush) Application.Current.Resources["primaryColor"];
        private static readonly Brush _secondaryColor = (Brush)Application.Current.Resources["secondaryColor"];

        private Ellipse _ellipse;
        private Grid _bodyGrid;

        static FloatingActionButton() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatingActionButton), new FrameworkPropertyMetadata(typeof(FloatingActionButton)));
        }

        public Brush HighlightColor {
            get { return (Brush)GetValue(HighlightColorProperty); }
            set { SetValue(HighlightColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightColorProperty =
            DependencyProperty.Register(nameof(HighlightColor), typeof(Brush), typeof(FloatingActionButton), new PropertyMetadata(Brushes.Red));


        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            if (this.Template != null) {
                _ellipse = GetTemplateChild<Ellipse>(PART_ELLIPSE);
                _bodyGrid = GetTemplateChild<Grid>(PART_BODY);

                if (_ellipse != null) {
                    _ellipse.Fill = _primaryColor;
                    _bodyGrid.MouseEnter += (sender, e) => {
                        _ellipse.Fill = _secondaryColor;
                    };

                    _bodyGrid.MouseLeave += (sender, e) => {
                        _ellipse.Fill = _primaryColor;
                    };
                }

            }
        }

        T GetTemplateChild<T>(string name) where T : DependencyObject {
            var child = GetTemplateChild(name) as T;

            if (child is null) {
                throw new NullReferenceException(name);
            }

            return child;
        }
    }
}
