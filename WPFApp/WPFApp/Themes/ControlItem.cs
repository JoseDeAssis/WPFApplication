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
    public class ControlItem : TextBlock {
        static ControlItem() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ControlItem), new FrameworkPropertyMetadata(typeof(ControlItem)));
        }

        public Type ControlType {
            get { return (Type)GetValue(ControlTypeProperty); }
            set { SetValue(ControlTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlTypeProperty =
            DependencyProperty.Register("MyProperty", typeof(Type), typeof(ControlItem), new PropertyMetadata(null));

    }
}
