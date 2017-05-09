using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidades.Pagamento
{
    public class SenderDocumentPagSeguro
    {
        [XmlElement(ElementName = "type")]
        public string Type { get { return "CPF"; } set { } }
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
}
