using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Interfaces
{
    public class GoogleDriveService : CloudService
    {
        public GoogleDriveService() : base("https://drive.google.com/drive/u/0/my-drive")
        {
        }

        public override void UploadData(string file)
        {
            Console.WriteLine($"File {file} was uploaded to Google Drive.");
        }

        public override string DownloadData(string file)
        {
            Console.WriteLine($"Downloading file {file} from Google Drive...");
            return "In this article I will describe CQRS pattern on very simple example.";
        }
    }
}
