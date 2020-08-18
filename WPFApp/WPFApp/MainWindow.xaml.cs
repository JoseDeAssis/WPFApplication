using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using WPFApp.Themes;

namespace WPFApp {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Loaded += (obj, e) => {
                ReflectionTest.runReflection();
            };

            //Grid grid = new Grid();
            //this.Content = grid;

            //Button button = new Button();
            //button.Width = 200;
            //button.Height = 100;
            //button.FontSize = 20;

            //WrapPanel wrapPanel = new WrapPanel();
            //TextBlock textBlock = new TextBlock();

            //textBlock.Text = "Multi";
            //textBlock.Foreground = Brushes.Blue;
            //wrapPanel.Children.Add(textBlock);

            //textBlock = new TextBlock();
            //textBlock.Text = "Color";
            //textBlock.Foreground = Brushes.Red;
            //wrapPanel.Children.Add(textBlock);

            //textBlock = new TextBlock();
            //textBlock.Text = "Button";
            //textBlock.Foreground = Brushes.Green;
            //wrapPanel.Children.Add(textBlock);

            //button.Content = wrapPanel;
            //grid.Children.Add(button);


            //FloatingActionButton.Click += new RoutedEventHandler(ShowMsg);
        }

        private void ShowMsg(object sender, RoutedEventArgs e) {
            MessageBox.Show("This is a FAB!");
        }

        private void DragStart(object sender, MouseButtonEventArgs e) {
            TextBlock textBlock = sender as TextBlock;
            string tooltip = textBlock.ToolTip.ToString();

            Type objType = Type.GetType(tooltip);

            DataObject dataObj = new DataObject();
            //Object type = Activator.CreateInstance(tooltip.GetType());
            //MessageBox.Show(type.GetType().ToString());

            dataObj.SetData("Type", objType);

            DragDrop.DoDragDrop(sender as DependencyObject, dataObj, DragDropEffects.Move);
        }

        private void DropTarget(object sender, DragEventArgs e) {
            //string type = e.Data.GetData("Type").ToString();

            //UIElement newChild = new UIElement();

            //switch (type) {
            //    case "FloatingActionButton":
            //        var fab = new FloatingActionButton();
            //        newChild = fab;
            //        break;
            //    case "Label":
            //        var label = new Label();
            //        label.Content = "Label 1";
            //        newChild = label;
            //        break;
            //}

            Type objType = e.Data.GetData("Type") as Type;

            UIElement newChild = Activator.CreateInstance(objType) as UIElement;

            PropertyInfo width = objType.GetProperty("Width");
            PropertyInfo height = objType.GetProperty("Height");
            PropertyInfo IsHitTestVisible = objType.GetProperty("IsHitTestVisible");

            width.SetValue(newChild, 100);
            height.SetValue(newChild, 100);
            IsHitTestVisible.SetValue(newChild, false);


            InkCanvas canvas = sender as InkCanvas;

            Double x = e.GetPosition(CanvasDrop).X;
            Double y = e.GetPosition(canvas).Y;

            InkCanvas.SetTop(newChild, y);
            InkCanvas.SetLeft(newChild, x);

            CanvasDrop.Children.Add(newChild);
        }
        void RotateRight(object sender, RoutedEventArgs e) {
            TransformGroup transformGroup = new TransformGroup();
            ScaleTransform scaleTransform = new ScaleTransform();
            RotateTransform rotateTransform = new RotateTransform();
            TranslateTransform translateTransform = new TranslateTransform();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);

            this.CanvasDrop.RenderTransform = transformGroup;
            //this.CanvasDrop.GetSelectedStrokes();
            //imgViewbox.RenderTransformOrigin = new Point(0.5, 0.5);
            rotateTransform.Angle += 10;
        }
        void RotateLeft(object sender, RoutedEventArgs e) {
            TransformGroup transformGroup = new TransformGroup();
            ScaleTransform scaleTransform = new ScaleTransform();
            RotateTransform rotateTransform = new RotateTransform();
            TranslateTransform translateTransform = new TranslateTransform();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(translateTransform);
            //imgViewbox.RenderTransformOrigin = new Point(0.5, 0.5);
            rotateTransform.Angle -= 10;
        }

    }
}
