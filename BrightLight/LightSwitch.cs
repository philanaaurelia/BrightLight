using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging; //BitmapImage
using System; //Uri
using Windows.UI.Xaml.Input;
using System.ComponentModel;

namespace BrightLight
{
    public class LightSwitch : INotifyPropertyChanged
    {
        private bool _isOn = false;
        public bool isOn
        {
            get
            {
                return _isOn;
            }
        }
        private Image _image;
        private static LightSwitch lightSwitch = null;
        public event PropertyChangedEventHandler PropertyChanged;

        public static void SetUp(Image image)
        {

            if(lightSwitch == null)
            {
                lightSwitch = new LightSwitch(image);
            }

        }

        private LightSwitch(Image image)
        {
            _image = image;
            _image.Tapped += new TappedEventHandler(onLightSwitchTapped);
        }

        public static LightSwitch getInstance()
        {
            return lightSwitch;
        }

        public void onLightSwitchTapped(object sender, TappedRoutedEventArgs e)
        {
            _isOn = !_isOn;
            if (!_isOn)
                _image.Source = new BitmapImage(new Uri("ms-appx:///Assets/switch_off.png"));
            else
                _image.Source = new BitmapImage(new Uri("ms-appx:///Assets/switch_on.png"));
        
            onPropertyChanged("isOn");
        }

            // Create the OnPropertyChanged method to raise the event 
      protected void onPropertyChanged(string name)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(name));
          }
      }

    }
}