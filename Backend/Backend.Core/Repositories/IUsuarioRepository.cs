using Backend.Core.Entities;
using Backend.Core.Repositories.Base;

namespace Backend.Core.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllUsuarioWithTipousuario();
    }
}
