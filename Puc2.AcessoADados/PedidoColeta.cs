using Newtonsoft.Json;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Puc2.AcessoADados
{
    public class PedidoColeta
    {
        public List<Modelo.PedidoColetaView> Listar()
        {
            using (var context = new MyDbContext())
            {
                return context.PedidoColetas.Select(s => new Modelo.PedidoColetaView()
                {
                    idPedidoColeta = s.idPedidoColeta,
                    NomeCliente = s.NomeCliente,
                    AlturaEncomenda= s.AlturaEncomenda,
                    EnderecoCliente= s.EnderecoCliente,
                    LarguraEncomenda= s.LarguraEncomenda,
                    PesoEncomenda= s.PesoEncomenda,
                    ProfEncomenda= s.ProfEncomenda,
                    TelefoneCliente= s.TelefoneCliente,
                    EnderecoEntrega = s.EnderecoEntrega,
                    EndereRetirada = s.EndereRetirada
                }).ToList();
            }
        }

        public Modelo.PedidoColetaView PorId(long? id)
        {
            if (id == null)
                return null;

            using (var context = new MyDbContext())
            {
                return context.PedidoColetas.Where(w => w.idPedidoColeta == id).Select(s => new Modelo.PedidoColetaView()
                {
                    idPedidoColeta = s.idPedidoColeta,
                    NomeCliente = s.NomeCliente,
                    AlturaEncomenda = s.AlturaEncomenda,
                    EnderecoCliente = s.EnderecoCliente,
                    LarguraEncomenda = s.LarguraEncomenda,
                    PesoEncomenda = s.PesoEncomenda,
                    ProfEncomenda = s.ProfEncomenda,
                    TelefoneCliente = s.TelefoneCliente,
                    EnderecoEntrega = s.EnderecoEntrega,
                    EndereRetirada = s.EndereRetirada
                }).FirstOrDefault();
            }
        }

        public int? Incluir(Modelo.PedidoColetaView pedidocoleta)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    BaseDeDados.PedidoColeta bdpedidocoleta = new BaseDeDados.PedidoColeta();
                    // dicas em https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
                    bdpedidocoleta = JsonConvert.DeserializeObject<BaseDeDados.PedidoColeta>(JsonConvert.SerializeObject(pedidocoleta));

                    context.PedidoColetas.Add(bdpedidocoleta);
                    if (context.SaveChanges() > 0)
                        return pedidocoleta.idPedidoColeta;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int? Excluir(Modelo.PedidoColetaView pedidocoleta)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    BaseDeDados.PedidoColeta bdpedidocoleta = new BaseDeDados.PedidoColeta();

                    bdpedidocoleta = context.PedidoColetas.Find(pedidocoleta.idPedidoColeta);
                    context.PedidoColetas.Remove(bdpedidocoleta);
                    if (context.SaveChanges() > 0)
                        return pedidocoleta.idPedidoColeta;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int? Alterar(Modelo.PedidoColetaView pedidocoleta)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    BaseDeDados.PedidoColeta bdpedidocoleta = new BaseDeDados.PedidoColeta();
                    // dicas em https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
                    bdpedidocoleta = JsonConvert.DeserializeObject<BaseDeDados.PedidoColeta>(JsonConvert.SerializeObject(pedidocoleta));

                    context.Entry(bdpedidocoleta).State = EntityState.Modified;
                    if (context.SaveChanges() > 0)
                        return pedidocoleta.idPedidoColeta;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public Boolean Dispose()
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    context.Dispose();
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

    }
}
