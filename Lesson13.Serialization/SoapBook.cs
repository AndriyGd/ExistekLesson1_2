using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Serialization
{
    using System.Xml.Serialization;

    [Serializable]
    class SoapBook
    {
        private int _pages;

        public string Name { get; set; }
        public string Author { get; set; }
        [XmlElement("Published")]
        public int PublishYear { get; set; }
        public Chapets[] Chapets { get; set; }
        [XmlIgnore]
        public int Id { get; set; }

        public void SetPages(int pages)
        {
            _pages = pages;
        }

        public int GetPages()
        {
            return _pages;
        }

        public void AddChapet(Chapets chapets)
        {
            if (Chapets == null)
            {
                Chapets = new [] {chapets};
            }
            else
            {
                var temp = Chapets;
                Array.Resize(ref temp, Chapets.Length + 1);
                temp[temp.Length - 1] = chapets;

                Chapets = temp;
            }
        }
    }
}
