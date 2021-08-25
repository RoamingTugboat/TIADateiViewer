using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    public class group
    {
        [XmlAttribute]
        public string Name;
        public List<category> categories;
    }
}
