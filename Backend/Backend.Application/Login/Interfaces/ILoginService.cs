using Backend.Application.Login.DTOs;
using Backend.Core.Entities;

namespace Backend.Application.Login.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Verifica que el usuario exista en la bbdd
        /// </summary>
        /// <param name="pLoginDTO">Usuario que desea iniciar sesión</param>
        /// <returns></returns>
        Task<Usuario?> UserExists(LoginDTO pLoginDTO);

        /// <summary>
        /// Obtiene los datos del usuario logueado en el sistema
        /// </summary>
        /// <param name="pUserName"></param>
        /// <returns></returns>
        Task<Usuario> GetLoginUser(string pUserName);
    }
}
