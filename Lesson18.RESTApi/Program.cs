using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.Web;

namespace Lesson18.RESTApi
{
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://jsonplaceholder.typicode.com/users";
            var service = new UserService();

            var users = service.GetUsers(url);


            Console.ReadLine();
        }
    }

    class UserService
    {
        public List<User> GetUsers(string url)
        {
            var rawData = GetData(url);
            var users = JsonConvert.DeserializeObject<List<User>>(rawData);

            return users;
        }

        private string GetData(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var dataStream = response.GetResponseStream();
                if (dataStream == null) return string.Empty;

                var reader = new StreamReader(dataStream);
                var data = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

                return data;
            }
        }
    }
}
