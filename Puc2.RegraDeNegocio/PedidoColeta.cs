using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc2.RegraDeNegocio
{
    public class PedidoColeta
    {
        private Puc2.AcessoADados.PedidoColeta _acessoDados;

        public PedidoColeta()
        {
            _acessoDados = new AcessoADados.PedidoColeta();
        }

        public List<Modelo.PedidoColetaView> Listar()
        {
            return _acessoDados.Listar();
        }

        public Modelo.PedidoColetaView PorId(long? id)
        {
            return _acessoDados.PorId(id);
        }

        public int? Incluir(Modelo.PedidoColetaView coleta)
        {
            return _acessoDados.Incluir(coleta);
        }

        public int? Excluir(Modelo.PedidoColetaView coleta)
        {
            return _acessoDados.Excluir(coleta);
        }

        public int? Alterar(Modelo.PedidoColetaView coleta)
        {
            return _acessoDados.Alterar(coleta);
        }

        public Boolean Dispose()
        {
            return _acessoDados.Dispose();
        }

    }
}
