using Microsoft.EntityFrameworkCore;
using webApi.inlock.db.Contexts;
using webApi.inlock.db.Domains;
using webApi.inlock.db.Interfaces;

namespace webApi.inlock.db.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio busca = ctx.Estudios.Find(id);

            if (busca != null)
            {
                busca.Nome = estudio.Nome;

            }

            ctx.Estudios.Update(busca);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudio)
        {
            estudio.IdEstudio = Guid.NewGuid();
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);
            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
