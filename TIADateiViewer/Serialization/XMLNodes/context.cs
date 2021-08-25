using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TIADateiViewer
{
    public class context
    {
        [XmlAttribute]
        public string Name;
        public List<group> groups;
    }
}
