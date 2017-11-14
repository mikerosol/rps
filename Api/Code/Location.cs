//using System.Collections.Generic;
//using System.Linq;

//namespace Api.Code
//{
//    public class Location
//    {
//        public static List<Objects.Location> Get(int? locationId = null)
//        {
//            var locations = locationId == null ?
//                Api.Global.Repository.Locations :
//                Api.Global.Repository.Locations.Where(l => l.LocationId == locationId).ToList();

//            return locations;
//        }
//        public static Objects.Location Save(Objects.Location location)
//        {
//            var existingLocation = Api.Global.Repository.Locations
//                .SingleOrDefault(l => l.LocationId == location.LocationId);
                        
//            if (existingLocation == null)
//            {
//                //NEW LOCATION               
//                location.LocationId = location.LocationId > 0 ?
//                    location.LocationId :
//                    Api.Global.Repository.Locations.Max(l => l.LocationId) + 1;
                
//                Api.Global.Repository.Locations.Add(location);

//                return location;
//            }
//            else
//            {
//                //UPDATE EXISITNG LOCATION
//                if (string.IsNullOrEmpty(location.Address))
//                    existingLocation.Address = location.Address;

//                if (string.IsNullOrEmpty(location.City))
//                    existingLocation.City = location.City;
                                
//                existingLocation.State = location.State;

//                if (string.IsNullOrEmpty(location.ZipCode))
//                    existingLocation.ZipCode = location.ZipCode;

//                return existingLocation;
//            }
//        }
//        public static void Delete(int locationId)
//        {
//            Api.Global.Repository.Locations
//                .RemoveAll(l => l.LocationId == locationId);
//        }
//    }
//}