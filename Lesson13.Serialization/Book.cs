using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Serialization
{
    using System.Xml.Serialization;

    [Serializable]
    public class Book
    {
        private int _pages;

        public string Name { get; set; }
        public string Author { get; set; }
        [XmlElement("Published")]
        public int PublishYear { get; set; }
        public List<Chapets> Chapets { get; set; }
        [XmlIgnore]
        public int Id { get; set; } 

        public Book()
        {
            Chapets = new List<Chapets>();
        }

        public void SetPages(int pages)
        {
            _pages = pages;
        }

        public int GetPages()
        {
            return _pages;
        }
    }
}
