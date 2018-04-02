using Windows.UI.Xaml.Media;
using Windows.UI;

namespace BrightLight
{
    public class ColorPalette
    {
        public enum Value{NONE, RED, PURPLE, YELLOW, GREEN, PINK, ORANGE, BLUE, WHITE };
        private static Value _selected = Value.NONE;
        public static Value currentColor //set this as a property for notification?
        {
            get
            {
                return _selected;
            }
            protected set
            {
                _selected = value;
            }
        }

        public static Brush[] brush = new Brush[] { new SolidColorBrush(Colors.Transparent),
                                                    new SolidColorBrush(Colors.Red),
                                                    new SolidColorBrush(Colors.Purple),
                                                    new SolidColorBrush(Colors.Yellow), 
                                                    new SolidColorBrush(Colors.Green), 
                                                    new SolidColorBrush(Colors.Pink),
                                                    new SolidColorBrush(Colors.Orange), 
                                                    new SolidColorBrush(Colors.Blue),
                                                    new SolidColorBrush(Colors.White) };
        private static int brushListLength = brush.Length;
        public static int MAX_NUM
        {
            get
            {
                return brushListLength;
            }
        }
    }
}