using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.Linq.Mapping;

namespace Onde_esta_meu_carro.Src.Class
{
    [Table]
    class VehicleLocal  :   Model
    {
        [Column(IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id { get; set; }

        [Column(CanBeNull=false)]
        public double Latitude { get; set; }

        [Column(CanBeNull=false)]
        public double Longitude { get; set; }

        [Column(CanBeNull=false)]
        public DateTime DateCreation { get; set; }

        [Column(CanBeNull=false)]
        public bool IsActive { get; set; }

        [Column(CanBeNull=true)]
        public String UrlImage { get; set; }

        //  incomplete
        public ImageSource Image
        {
            get 
            {
                BitmapImage bmpImage = new BitmapImage(new Uri(UrlImage));

                return bmpImage;
            }
        }
    }
}
