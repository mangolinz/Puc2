using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc2.Modelo
{
    [Serializable]
    public class PedidoColetaView
    {
        [Key]
        public int idPedidoColeta { get; set; }

        [Display(Name = "Nome do cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "Endereço do cliente")]
        public string EnderecoCliente { get; set; }

        [Display(Name = "Telefone do cliente")]
        public string TelefoneCliente { get; set; }

        [Display(Name = "Largura da Encomenda")]
        public string LarguraEncomenda { get; set; }

        [Display(Name = "Altura da Encomenda")]
        public string AlturaEncomenda { get; set; }

        [Display(Name = "Profundidade da Encomenda")]
        public string ProfEncomenda { get; set; }

        [Display(Name = "Peso da Encomenda")]
        public string PesoEncomenda { get; set; }

        [Display(Name = "Endereço de retirada")]
        public string EndereRetirada { get; set; }

        [Display(Name = "Endereço de entrega")]
        public string EnderecoEntrega { get; set; }
    }
}
