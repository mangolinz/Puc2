using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Puc2.AcessoADados
{
    public class Coleta
    {
        public List<Modelo.ColetaView> Listar()
        {
            using (var context = new MyDbContext())
            {
                return context.Coletas.Select(s => new Modelo.ColetaView()
                {
                    idPedidoColeta = s.idPedidoColeta,
                    EnderecoEntrega = s.EnderecoEntrega,
                    EndereRetirada = s.EndereRetirada
                }).ToList();
            }
        }

        public Modelo.ColetaView PorId(long? id)
        {
            if (id == null)
                return null;

            using (var context = new MyDbContext())
            {
                return context.Coletas.Where(w => w.idPedidoColeta == id).Select(s => new Modelo.ColetaView() {
                    idPedidoColeta = s.idPedidoColeta,
                    EnderecoEntrega = s.EnderecoEntrega,
                    EndereRetirada = s.EndereRetirada
                }).FirstOrDefault();
            }
        }

        public int? Incluir(Modelo.ColetaView coleta)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    BaseDeDados.Coleta bdcoleta = new BaseDeDados.Coleta();
                    // dicas em https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
                    bdcoleta = JsonConvert.DeserializeObject<BaseDeDados.Coleta>(JsonConvert.SerializeObject(coleta));

                    context.Coletas.Add(bdcoleta);
                    if (context.SaveChanges() > 0)
                        return coleta.idPedidoColeta;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int? Excluir(Modelo.ColetaView coleta)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    BaseDeDados.Coleta bdcoleta = new BaseDeDados.Coleta();

                    bdcoleta = context.Coletas.Find(coleta.idPedidoColeta);
                    context.Coletas.Remove(bdcoleta);
                    if (context.SaveChanges() > 0)
                        return coleta.idPedidoColeta;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int? Alterar(Modelo.ColetaView coleta)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    BaseDeDados.Coleta bdcoleta = new BaseDeDados.Coleta();
                    // dicas em https://stackoverflow.com/questions/3672742/cast-class-into-another-class-or-convert-class-to-another
                    bdcoleta = JsonConvert.DeserializeObject<BaseDeDados.Coleta>(JsonConvert.SerializeObject(coleta));

                    context.Entry(bdcoleta).State = EntityState.Modified;
                    if (context.SaveChanges() > 0)
                        return coleta.idPedidoColeta;
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
