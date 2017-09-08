using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Onde_esta_meu_carro.Src.Page
{
    public partial class PhotoViewer : PhoneApplicationPage
    {

        public BitmapImage bitmapImage { get; set;  }

        public PhotoViewer()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (bitmapImage != null)
                imgViewer.Source = bitmapImage;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            bitmapImage = null;
        }
    }
}