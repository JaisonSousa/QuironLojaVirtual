using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidades.Pagamento
{
    public class SenderPhonePagSeguro
    {
        [XmlElement(ElementName = "areaCode")]
        public string AreaCode { get; set; }
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
    }
}
