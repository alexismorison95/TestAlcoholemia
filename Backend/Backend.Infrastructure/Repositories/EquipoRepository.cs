using Backend.Core.Entities;
using Backend.Core.Repositories;
using Backend.Infrastructure.DataContext;
using Backend.Infrastructure.Repositories.Base;

namespace Backend.Infrastructure.Repositories
{
    public class EquipoRepository : Repository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }
    }
}
