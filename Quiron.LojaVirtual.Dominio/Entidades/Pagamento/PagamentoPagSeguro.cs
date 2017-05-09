﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidades.Pagamento
{
    [XmlRoot("checkout")]
    public class PagamentoPagSeguro
    {

        #region StatesDictionary

        private Dictionary<string, string> states = new Dictionary<string, string>() {
            { "AC", "Acre"                   },
            { "AL", "Alagoas"                },
            { "AP", "Amapá"                  },
            { "AM", "Amazonas"               },
            { "BA", "Bahia"                  },
            { "CE", "Ceará"                  },
            { "DF", "Distrito Federal"       },
            { "ES", "Espírito Santo"         },
            { "GO", "Goiás"                  },
            { "MA", "Maranhão"               },
            { "MT", "Mato Grosso"            },
            { "MS", "Mato Grosso do Sul"     },
            { "MG", "Minas Gerais"           },
            { "PA", "Pará"                   },
            { "PB", "Paraíba"                },
            { "PR", "Paraná"                 },
            { "PE", "Pernambuco"             },
            { "PI", "Piauí"                  },
            { "RJ", "Rio de Janeiro"         },
            { "RN", "Rio Grande do Norte"    },
            { "RS", "Rio Grande do Sul"      },
            { "RO", "Rondônia"               },
            { "RR", "Roraima"                },
            { "SC", "Santa Catarina"         },
            { "SP", "São Paulo"              },
            { "SE", "Sergipe"                },
            { "TO", "Tocantins"              }
        };

        #endregion

        public PagamentoPagSeguro() { }

        public PagamentoPagSeguro(Pedido pedido, string redirectUrl, string requestIp)
        {
            Sender = new SenderPagSeguro()
            {
                IP = requestIp,
                Documents = new List<SenderDocumentPagSeguro>() {
                    new SenderDocumentPagSeguro()
                    {
                        Value = pedido.cliente.Documento.Valor.ToString()
                        //Cliente.Documento.Valor.ToString()
                    }
                },
                Phone = new SenderPhonePagSeguro()
                {
                    AreaCode = pedido.cliente.Telefone.CodigoArea,
                    Number = pedido.cliente.Telefone.Numero
                },
                Email = pedido.cliente.Email,
                Name = pedido.cliente.NomeCompleto
            };

            Items = new List<ItemPagSeguro>();
            foreach (var produto in pedido.ProdutosPedido)
            {
                Items.Add(new ItemPagSeguro()
                {
                    Id = produto.Id.ToString(),
                    Description = produto.Produto.ProdutoDescricao,
                    Amount = produto.Produto.Preco,
                    Quantity = produto.Quantidade
                });
            }

            RedirectURL = redirectUrl;

            Reference = pedido.Id.ToString();

            Shipping = new ShippingPagSeguro()
            {
                Address = new ShippingAddressPagSeguro()
                {
                    Street = pedido.cliente.Endereco.Rua,
                    City = pedido.cliente.Endereco.Cidade,
                    Complement = pedido.cliente.Endereco.Complemento,
                    District = pedido.cliente.Endereco.Bairro,
                    Number = pedido.cliente.Endereco.Numero,
                    PostalCode = pedido.cliente.Endereco.CEP,
                    State = states
                        .Where(s => s.Value.Equals(pedido.cliente.Endereco.Estado))
                        .FirstOrDefault().Key
                },
                Cost = "0",
                Type = 1
            };
        }









        [XmlElement(ElementName = "sender")]
        public SenderPagSeguro Sender { get; set; }

        [XmlElement(ElementName = "currency")]
        public string Currency { get { return "BRL"; } set { } }

        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<ItemPagSeguro> Items { get; set; }

        [XmlElement(ElementName = "redirectURL")]
        public string RedirectURL { get; set; }

        private decimal extraAmount;
        [XmlElement(ElementName = "extraAmount")]
        public string ExtraAmount
        {
            get { return extraAmount.ToString("n2"); }
            set { extraAmount = decimal.Parse(value); }
        }

        [XmlElement(ElementName = "reference")]
        public string Reference { get; set; }

        [XmlElement(ElementName = "shipping")]
        public ShippingPagSeguro Shipping { get; set; }

        [XmlElement(ElementName = "maxAge")]
        public int MaxAge { get { return 600; } set { } } // em segundos

        [XmlElement(ElementName = "maxUses")]
        public int MaxUses { get { return 1; } set { } }

        [XmlElement(ElementName = "receiver")]
        public ReceiverPagSeguro Receiver { get; set; }
    }
}
