using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidades.Pagamento
{
    public class ReceiverPagSeguro
    {
        [XmlElement(ElementName = "email")]
        public string Email { get { return "hmgasparotto@hotmail.com"; } set { } }
    }
}
