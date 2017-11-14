//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Api.Code
//{
//    public class Home
//    {
//        public static List<Objects.Home> Get(int? homeId = null)
//        {
//            var homes = homeId == null ?
//                Api.Global.Repository.Homes :
//                Api.Global.Repository.Homes
//                    .Where(h => h.HomeId == homeId)
//                    .ToList();

//            foreach (var home in homes)
//            {
//                if (home.Location.LocationId > 0)
//                {
//                    home.Location = Api.Code.Location
//                        .Get(home.Location.LocationId)
//                        .SingleOrDefault();
//                }
//            }

//            return homes;
//        }
//        public static Objects.Home Save(Objects.Home home)
//        {
//            var existingHome = Api.Global.Repository.Homes
//                .SingleOrDefault(h => h.HomeId == home.HomeId);

//            if (existingHome == null)
//            {
//                //NEW HOME               
//                home.HomeId = home.HomeId > 0 ?
//                    home.HomeId :
//                    Api.Global.Repository.Homes.Max(p => p.HomeId) + 1;

//                home.Location = Api.Code.Location.Save(home.Location);

//                Api.Global.Repository.Homes.Add(home);

//                return home;
//            }
//            else
//            {
//                //UPDATE EXISITNG HOME
//                existingHome.RiskConstruction = home.RiskConstruction;

//                if (home.RiskYearBuilt > 0)
//                    existingHome.RiskYearBuilt = home.RiskYearBuilt;

//                if (home.Location != null)
//                    existingHome.Location = Api.Code.Location.Save(home.Location);

//                return existingHome;
//            }
//        }
//        public static void Delete(int homeId)
//        {
//            Api.Global.Repository.Homes
//                .RemoveAll(h => h.HomeId == homeId);
//        }
//    }
//}