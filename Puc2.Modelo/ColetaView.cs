using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc2.Modelo
{
    [Serializable]
    public class ColetaView
    {
        [Key]
        [Display(Name = "Nr da Coleta")]
        public int idPedidoColeta { get; set; }

        [Display(Name = "Endereço de retirada")]
        public string EndereRetirada { get; set; }

        [Display(Name = "Endereço de entrega")]
        public string EnderecoEntrega { get; set; }

    }
}
