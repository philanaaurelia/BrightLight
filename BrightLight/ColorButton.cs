using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using System.Collections.Generic;
using Windows.UI;

namespace BrightLight
{
    public class ColorButtonCollection : ColorPalette
    {
        private static ColorPalette.Value color = ColorPalette.Value.RED;
        private List<Button> buttons = new List<Button>();
        public List<Button> colorButtons
        {
            get
            {
                return buttons;
            }
        }

        public ColorButtonCollection()
        {
            for (int i = (int)ColorPalette.Value.RED; i < ColorPalette.MAX_NUM; ++i)
            {
                ColorButton button = new ColorButton(ColorPalette.brush[(int)color], color);
                color = (ColorPalette.Value)((int)color + 1);
                buttons.Add(button);
            }
        }

        public class ColorButton : Button
        {
            ColorPalette.Value colorValue;
            public ColorButton(Brush bgColor, ColorPalette.Value value)
            {
                colorValue = value;
                this.Width = 90;
                this.Height = 90;
                this.Background = bgColor;
                this.BorderThickness = new Thickness(0);
                this.Click += new RoutedEventHandler(onButtonClicked);
            }

            public void onButtonClicked(object sender, RoutedEventArgs e)
            {
                ColorPalette.currentColor = colorValue;
                colorValue = ColorPalette.currentColor;
                colorValue = ColorPalette.currentColor;
                //notify property change?
            }
        }
    }

}