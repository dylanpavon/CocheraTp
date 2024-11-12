using CocheraTp.Models;
using CocheraTp.Repository.CarpetaRepositoryUsuario.UnitOfWorkUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Servicios.UsuarioServicio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWorkUsuario _unitOfWork;

        public UsuarioService(IUnitOfWorkUsuario unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUsuario(USUARIO usuario)
        {
            var creado = await _unitOfWork.UsuarioRepository.CreateUsuario(usuario);
            if (creado)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var drop = await _unitOfWork.UsuarioRepository.DeleteUsuario(id);
            if (drop)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<USUARIO>> GetAllUsuario()
        {
            return await _unitOfWork.UsuarioRepository.GetAllUsuario();
        }

        public async Task<bool> UpdateUsuario(int id, USUARIO usuario)
        {
            var update = await _unitOfWork.UsuarioRepository.UpdateUsuario(id, usuario);
            if (update)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
