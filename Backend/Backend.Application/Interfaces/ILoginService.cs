
using Backend.Application.DTOs.Login;
using Backend.Core.Entities;

namespace Backend.Application.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Verifica que el usuario exista en la bbdd
        /// </summary>
        /// <param name="pLoginDTO">Usuario que desea iniciar sesión</param>
        /// <returns></returns>
        Task<Usuario?> UserExists(LoginDTO pLoginDTO);
    }
}
