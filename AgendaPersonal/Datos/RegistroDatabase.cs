using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AgendaPersonal.Modelos;
using System.Diagnostics;

namespace AgendaPersonal.Datos
{
    public class RegistroDatabase
    {
        private SQLiteAsyncConnection _db;

        public RegistroDatabase()
        {
            Inicializar();
        }

        private async void Inicializar()
        {
            if (_db != null) return;

            try
            {
                var rutaDB = Path.Combine(FileSystem.AppDataDirectory, "appmovil.db");
                _db = new SQLiteAsyncConnection(rutaDB);

                await _db.CreateTableAsync<Contacto>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al inicializar DB: {ex.Message}");
            }
        }

        public async Task<int> GuardarUsuarioAsync(Contacto contacto)
        {
            try
            {
                return contacto.Id == 0 ?
                    await _db.InsertAsync(contacto) :
                    await _db.UpdateAsync(contacto);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al guardar usuario: {ex.Message}");
                return 0;
            }
        }

        public async Task<bool> ExisteUsuarioAsync(string nombreUsuario)
        {
            try
            {
                return await _db.Table<Contacto>()
                    .Where(u => u.Nombre == nombreUsuario)
                    .CountAsync() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al verificar usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            try
            {
                return await _db.Table<Contacto>()
                    .Where(u => u.CorreoElectronico == email)
                    .CountAsync() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al verificar email: {ex.Message}");
                return false;
            }
        }

        public async Task<Contacto> ObtenerUsuarioAsync(string nombreUsuario)
        {
            try
            {
                return await _db.Table<Contacto>()
                    .Where(u => u.Nombre == nombreUsuario && u.Activo)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al obtener usuario: {ex.Message}");
                return null;
            }
        }
    }
}
