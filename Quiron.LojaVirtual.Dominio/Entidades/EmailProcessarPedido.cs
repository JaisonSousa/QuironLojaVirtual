﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using(var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp);

               if (_emailConfiguracoes.EscreverArquivo)
               {
                   smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                   smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                   smtpClient.EnableSsl = false;

               }

                StringBuilder body = new StringBuilder().AppendLine("Novo Pedido")
                    .Append("------")
                    .Append("Itens");
                foreach (var item in carrinho.ItensCarrinhos)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} * {1} (subtotal: {2:c}", item.Quantidade,item.Produto.ProdutoDescricao, subtotal);
                }

                body.AppendFormat("Valor total do pedido:{0:c}",carrinho.ObterValorTotal())
                    .AppendLine("------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.cliente.NomeCompleto)
                    .AppendLine(pedido.cliente.Email)
                    .AppendLine(pedido.cliente.Endereco.Rua ?? ", " + pedido.cliente.Endereco.Numero ?? "")
                    .AppendLine(pedido.cliente.Endereco.Cidade ?? "")
                    .AppendLine(pedido.cliente.Endereco.Complemento ?? "")
                    .AppendLine("------------------")
                    .AppendFormat("Para presente?: {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De,_emailConfiguracoes.Para, "Novo periodo", body.ToString());


                if (_emailConfiguracoes.EscreverArquivo)
	            {

                      mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
		 
	            }


                smtpClient.Send(mailMessage);

        

            }

        }
    }
}
