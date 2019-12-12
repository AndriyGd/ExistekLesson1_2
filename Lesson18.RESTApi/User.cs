using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18.RESTApi
{
    /*
     * "id": 1,
       "name": "Leanne Graham",
       "username": "Bret",
       "email": "Sincere@april.biz",
       "phone": "1-770-736-8031 x56442",
       "website": "hildegard.org",
     */
    class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
    }
}
