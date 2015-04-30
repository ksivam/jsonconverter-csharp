using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonConverter
{
    public class AuthorizationProfile
    {
        public DateTime requestedTime { get; set; }

        public string requester { get; set; }
    }

    public class Registration
    {
        public string subscriptionId { get; set; }

        public AuthorizationProfile authorizationProfile { get; set; }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Registration> registrations = JsonConvert.DeserializeObject<List<Registration>>(jsonString.json);
            List<Registration> externalCustomers = new List<Registration>();            

            foreach (Registration reg in registrations)
            {
                if (!reg.authorizationProfile.requester.Contains("microsoft.com") && reg.authorizationProfile.requestedTime > new DateTime(2015, 4, 28, 23, 59, 0))
                {
                    externalCustomers.Add(reg);
                }
            }

            Console.WriteLine("Total Count: " + externalCustomers.Count);
            Console.WriteLine("email, subscription");
            foreach (Registration external in externalCustomers)
            {
                Console.WriteLine(string.Format("{1},{0}", external.subscriptionId, external.authorizationProfile.requester));
            }

            Console.ReadKey();
        }
    }
}
