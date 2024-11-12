using CocheraTp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocheraTp.Repository.CarpetaRepositoryLugar.Interfaces
{
    public class LugarRepository : ILugarRepository
    {
        private readonly db_cocherasContext _context;
        public LugarRepository(db_cocherasContext context)
        {
            _context = context;
        }

        public async Task<List<LUGARE>> GetAllLugares()
        {
            return await _context.LUGAREs.ToListAsync();
        }

        public async Task<List<LUGARE>> GetLugaresDisponibles()
        {
            return await _context.LUGAREs
                                  .Where(l => l.seccion_uno == false && l.seccion_dos == false)
                                  .ToListAsync();
        }

        public async Task<bool> ActualizarSecciones(string idLugar, int idVehiculo, bool ingreso)
        {
            var lugar = await _context.LUGAREs
            .Include(l => l.DETALLE_FACTURAs)
            .ThenInclude(df => df.id_vehiculoNavigation)
            .FirstOrDefaultAsync(l => l.id_lugar == idLugar);

            if (lugar == null)
            {
                return false;
            }

            var detalleFactura = lugar.DETALLE_FACTURAs.
                FirstOrDefault(df => df.id_vehiculo == idVehiculo);

            if (detalleFactura == null || detalleFactura.id_vehiculoNavigation == null)
            {
                return false;
            }

            var tipoVehiculo = detalleFactura.id_vehiculoNavigation.id_tipo_vehiculo;

            if (ingreso)
            {
                switch (tipoVehiculo)
                {
                    case 1:
                    case 3:

                        lugar.seccion_uno = true;
                        lugar.seccion_dos = true;
                        break;
                    case 2:

                        if (lugar.seccion_uno == true)
                        {
                            lugar.seccion_dos = true;
                        }
                        else
                        {
                            lugar.seccion_uno = true;
                        }
                        break;
                    default:
                        return false;
                }
            }
            else
            {
                switch (tipoVehiculo)
                {
                    case 1:
                    case 3:

                        lugar.seccion_uno = false;
                        lugar.seccion_dos = false;
                        break;
                    case 2:

                        if (lugar.seccion_dos == true)
                        {
                            lugar.seccion_dos = false;
                        }
                        else
                        {
                            lugar.seccion_uno = false;
                        }
                        break;
                    default:
                        return false;
                }
            }

            _context.LUGAREs.Update(lugar);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
