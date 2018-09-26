using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc2.RegraDeNegocio
{
    public class Coleta
    {
        private Puc2.AcessoADados.Coleta _acessoDados;

        public Coleta()
        {
            _acessoDados = new AcessoADados.Coleta();
        }

        public List<Modelo.ColetaView> Listar()
        {
            return _acessoDados.Listar();
        }

        public Modelo.ColetaView PorId(long? id)
        {
            return _acessoDados.PorId(id);
        }

        public int? Incluir(Modelo.ColetaView coleta)
        {
            return _acessoDados.Incluir(coleta);
        }

        public int? Excluir(Modelo.ColetaView coleta)
        {
            return _acessoDados.Excluir(coleta);
        }

        public int? Alterar(Modelo.ColetaView coleta)
        {
            return _acessoDados.Alterar(coleta);
        }

        public Boolean Dispose()
        {
            return _acessoDados.Dispose();
        }
        
    }
}
