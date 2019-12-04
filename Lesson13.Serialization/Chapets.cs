using System.Xml.Serialization;

namespace Lesson13.Serialization
{
    using System;

    [XmlType("BookChapet")]
    [Serializable]
    public class Chapets
    {
        public string Name { get; set; }
        [XmlAttribute("startPage")]
        public int StartPage { get; set; }
        [XmlAttribute("endPage")]
        public int EndPage { get; set; }
    }
}
