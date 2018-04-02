using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging; //BitmapImage

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BrightLight
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool _isLightOn;
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LightSwitch.SetUp(LightSwitchImg);
            ColorButtonCollection buttonCollection = new ColorButtonCollection();
            ColorGrid.ItemsSource = buttonCollection.colorButtons;
            PegGrid.SetCanvas(PegCanvas);

            for (int i = 0; i < PegGrid.TOTAL_PEGS; i++)
            {
                PegItem peg = new PegItem();
                PegCanvas.Children.Add(peg.image);
            }
        }
    }
}
