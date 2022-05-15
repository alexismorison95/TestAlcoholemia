using Backend.Core.Entities;
using Backend.Core.Repositories;
using Backend.Infrastructure.DataContext;
using Backend.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TallerContext pTallerContext) : base(pTallerContext)
        {
        }

        new public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _tallerContext.Usuarios.Include(x => x.Tipousuario).ToListAsync();
        }
    }
}
