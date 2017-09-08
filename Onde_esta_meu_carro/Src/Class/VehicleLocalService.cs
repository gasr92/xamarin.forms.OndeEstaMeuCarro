using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Onde_esta_meu_carro.Src.Class
{
    class VehicleLocalService
    {

        private static void SavePosition(GeoCoordinate gCoordinate)
        {
            VehicleLocal objVehicle = new VehicleLocal();

            objVehicle.IsActive = true;
            objVehicle.Latitude = gCoordinate.Latitude;
            objVehicle.Longitude = gCoordinate.Longitude;
            objVehicle.DateCreation = DateTime.Now;

            VehicleLocalDB.SaveVehicle(objVehicle);
        }

        public static bool SetLocal(GeoCoordinate gCoordinate)
        {
            List<VehicleLocal> lstLocal = null;

            lstLocal = VehicleLocalDB.GetActiveVehicleLocal();

            if (lstLocal.Count > 0)
                return false;

            SavePosition(gCoordinate);

            return true;
        }

        public static GeoCoordinate GetMyVehicleCoordinate()
        {
            List<VehicleLocal> lstVehicle = VehicleLocalDB.GetActiveVehicleLocal();

            if (lstVehicle.Count == 0)
                return null;

            double dblLongitude = lstVehicle[0].Longitude;
            double dblLatitude = lstVehicle[0].Latitude;

            return new GeoCoordinate(dblLatitude, dblLongitude);
        }

        public static int CountActive()
        {
            List<VehicleLocal> lstVehicle = VehicleLocalDB.GetActiveVehicleLocal();

            return lstVehicle.Count;
        }

        public static void DisableActiveLocal()
        {
            VehicleLocalDB.InactivateActiveLocal();
        }

    }
}
