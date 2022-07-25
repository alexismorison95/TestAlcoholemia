using Backend.Core.Entities;
using Backend.Core.Repositories;
using Backend.Infrastructure.DataContext;
using Backend.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarioExtended()
        {
            return await _tallerContext.Usuarios
                .Include(x => x.Tipousuario)
                .ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByNombreUsuario(string pNombreusuario)
        {
            return await _tallerContext.Usuarios
                .Where(x => x.Nombreusuario == pNombreusuario)
                .FirstOrDefaultAsync();
        }
    }
}
