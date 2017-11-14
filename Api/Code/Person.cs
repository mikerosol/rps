//using System.Collections.Generic;
//using System.Linq;

//namespace Api.Code
//{
//    public class Person
//    {
//        public static List<Objects.Person> Get(int? personId = null)
//        {
//            var people = personId == null ?
//                Api.Global.Repository.People :
//                Api.Global.Repository.People.Where(p => p.PersonId == personId).ToList();

//            foreach (var person in people)
//            {
//                if (person.Residence.LocationId > 0)
//                {
//                    person.Residence = Api.Code.Location.Get(person.Residence.LocationId)
//                        .SingleOrDefault();
//                }
//            }

//            return people;
//        }
//        public static Objects.Person Save(Objects.Person person)
//        {
//            var existingPerson = Api.Global.Repository.People
//                .SingleOrDefault(p => p.PersonId == person.PersonId);

//            if (existingPerson == null)
//            {
//                //NEW PERSON               
//                person.PersonId = person.PersonId > 0 ? 
//                    person.PersonId :
//                    Api.Global.Repository.People.Max(p => p.PersonId) + 1;

//                person.Residence = Api.Code.Location.Save(person.Residence);

//                Api.Global.Repository.People.Add(person);

//                return person;
//            }
//            else
//            {
//                //UPDATE EXISITNG PERSON
//                if (string.IsNullOrEmpty(person.FirstName))
//                    existingPerson.FirstName = person.FirstName;

//                if (string.IsNullOrEmpty(person.LastName))
//                    existingPerson.LastName = person.LastName;

//                if (person.Residence != null)
//                    existingPerson.Residence = Api.Code.Location.Save(person.Residence);

//                return existingPerson;
//            }
//        }
//        public static void Delete(int personId)
//        {
//            Api.Global.Repository.People
//                .RemoveAll(p => p.PersonId == personId);
//        }
//    }
//}