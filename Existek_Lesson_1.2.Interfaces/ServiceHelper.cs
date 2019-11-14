using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Interfaces
{
    public class ServiceHelper
    {
        private readonly List<CloudService> _services;

        public ServiceHelper()
        {
            _services = new List<CloudService>();
        }

        public void AddService(CloudService service)
        {
            if (service.Connect())
            {
                _services.Add(service);
            }
        }

        public void Upload(string file)
        {
            _services.ForEach(s => s.UploadData(file));
        }

        public void Download(string file)
        {
            _services.ForEach(s => Console.WriteLine(s.DownloadData(file)));
        }
    }
}
