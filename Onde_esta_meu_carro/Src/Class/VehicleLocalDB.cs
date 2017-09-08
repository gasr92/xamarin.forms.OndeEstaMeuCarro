using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Diagnostics;

namespace Onde_esta_meu_carro.Src.Class
{

    class DataBase : DataContext
    {
        public static string sConnectionString = "Data Source='isostore:db_where_ir_my_car.sdf'";

        public DataBase()
            : base(sConnectionString)
        {

        }

        public Table<VehicleLocal> VehicleLocal
        {
            get
            {
                return this.GetTable<VehicleLocal>();
            }
        }

    }

    class VehicleLocalDB
    {

        private static DataBase getDataBase()
        {
            DataBase db = new DataBase();

            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        /// <summary>
        /// Insert a new active position
        /// </summary>
        /// <param name="p_vechicle"></param>
        public static void SaveVehicle(VehicleLocal p_vechicle)
        {
            DataBase db = getDataBase();
            try
            {
                db.VehicleLocal.InsertOnSubmit(p_vechicle);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Return a list of active places
        /// </summary>
        /// <returns>List of type: VehicleLocal</returns>
        public static List<VehicleLocal> GetActiveVehicleLocal()
        {
            DataBase db = getDataBase();

            try
            {
                var query = from l in db.VehicleLocal where l.IsActive == true select l;

                List<VehicleLocal> vehicleLocal = new List<VehicleLocal>(query.AsEnumerable());

                //if (vehicleLocal.Count == 0)
                //    return null;

                return vehicleLocal;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;

        }

        /// <summary>
        /// Inactivate the actual position of the vehicle
        /// </summary>
        public static void InactivateActiveLocal()
        {
            DataBase db = getDataBase();


            var query = from row in db.VehicleLocal where row.IsActive == true select row;

            foreach (var ret in query)
            {
                ret.IsActive = false;
            }

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

    }
}
