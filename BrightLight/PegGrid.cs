using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging; //BitmapImage
using System; //Uri

namespace BrightLight
{
    public class PegGrid
    {
        public const int TOTAL_PEGS = 1913;
        protected const int PEG_TOP_INCREMENT = 18;
        protected const int PEG_LEFT_INCREMENT = 24;
        protected const int PEG_LEFT_ADJUSTMENT = PEG_LEFT_INCREMENT / 2;
        protected const int PEGS_PER_SHORT_ROW = 43;
        protected const int PEGS_PER_LONG_ROW = 44;
        protected static int topIndex = PEG_TOP_INCREMENT;
        protected static int leftIndex = PEG_LEFT_INCREMENT;
        protected static int currentRowLength = PEGS_PER_LONG_ROW;
        protected static int pegRowCount = 0;
        protected static int totalPegs = 0;
        protected static bool isLongRow = true;
        protected static Canvas canvas;
        //get together the image

        public static void SetCanvas(Canvas c)
        {
            canvas = c;
        }
    }

    public class PegItem : PegGrid
    {
        private int top;
        private int left;
        private int pegIndex;
        private PegImage pegImage;
        public Image image
        {
            get
            {
                return pegImage.source;
            }
        }

        public PegItem()
        {
            pegImage = new PegImage(onLightSwitchChanged);
            pegImage.source.Tapped += new TappedEventHandler(onItemTapped);
            top = topIndex;
            left = leftIndex;
            pegIndex = totalPegs++;
            pegRowCount++;
            Canvas.SetTop(pegImage.source, top);
            Canvas.SetLeft(pegImage.source, left);
            adjustPegCanvasPosition();
        }

        private void adjustPegCanvasPosition()
        {
            if (pegRowCount % currentRowLength == 0)
            {
                if (isLongRow)
                {
                    leftIndex = PEG_LEFT_ADJUSTMENT;
                    currentRowLength = PEGS_PER_SHORT_ROW;
                }
                else
                {
                    leftIndex = PEG_LEFT_INCREMENT;
                    currentRowLength = PEGS_PER_LONG_ROW;
                }

                isLongRow = !isLongRow;
                topIndex += PEG_TOP_INCREMENT;
                pegRowCount = 0;
            }
            else
                leftIndex += PEG_LEFT_INCREMENT;
        }

        private void onItemTapped(object sender, TappedRoutedEventArgs e)
        {
            if (pegImage.isEmpty)
                pegImage.update();
            else
                pegImage.reset();

            reposition();
        }

        public void onLightSwitchChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!pegImage.isEmpty)
            {
                pegImage.update();
                reposition();
            }
        }

        private void reposition()
        {
            if (pegImage.isLit)
            {

                Canvas.SetTop(pegImage.source, top - 7);
                Canvas.SetLeft(pegImage.source, left - 7);
            }
            else
            {
                Canvas.SetTop(pegImage.source, top);
                Canvas.SetLeft(pegImage.source, left);
            }

        }
    }

    public class PegImage
    {
        LightSwitch lightSwitch;
        private bool isImageEmpty;
        public bool isEmpty
        {
            get
            {
                return isImageEmpty;
            }
        }

        public bool isLit
        {
            get
            {
                return lightSwitch.isOn;
            }
        }

        private Image _image;
        public Image source
        {
            get
            {
                return _image;
            }
        }

        public PegImage(PropertyChangedEventHandler func)
        {
            _image = new Image();
            reset();
            lightSwitch = LightSwitch.getInstance();
            lightSwitch.PropertyChanged += new PropertyChangedEventHandler(func);
        }


        public void reset()
        {
            _image.Source = new BitmapImage(new Uri("ms-appx:///Assets/peghole.png"));
            isImageEmpty = true;
        }

        public void update()
        {
            Uri uri;
            switch (ColorPalette.currentColor)
            {
                case ColorPalette.Value.RED:
                    uri = lightSwitch.isOn ? new Uri("ms-appx:///Assets/red_lit.png") : new Uri("ms-appx:///Assets/red.png");
                    break;
                case ColorPalette.Value.BLUE:
                    uri = lightSwitch.isOn ? new Uri("ms-appx:///Assets/red_lit.png") : new Uri("ms-appx:///Assets/red.png");
                    break;
                case ColorPalette.Value.PURPLE:
                    uri = lightSwitch.isOn ? new Uri("ms-appx:///Assets/violet_lit.png") : new Uri("ms-appx:///Assets/violet.png");
                    break;
                default:
                    uri = null;
                    break;
            }

            if (uri == null)
                isImageEmpty = true;
            else
            {   
                _image.Source = new BitmapImage(uri);
                isImageEmpty = false;
            }

        }
    }
}