using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Puc2.Mvc.Entidades
{
    public class Coleta
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