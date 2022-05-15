using Backend.Core.Entities;
using Backend.Core.Repositories;
using Backend.Infrastructure.DataContext;
using Backend.Infrastructure.Repositories.Base;

namespace Backend.Infrastructure.Repositories
{
    public class TipousuarioRepository : Repository<Tipousuario>, ITipousuarioRepository
    {
        public TipousuarioRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }
    }
}
