using Firebase.Database;
using Newtonsoft.Json;
using Reserva_Computadoras_Tecsup.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup
{
    public class ComputerRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://reservacomputadorastecsup-default-rtdb.firebaseio.com/");
        
        public async Task<bool> Save(Computer computer)
        {
            var data = await firebaseClient.Child(nameof(Computer)).PostAsync(JsonConvert.SerializeObject(computer));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Computer>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Computer)).OnceAsync<Computer>()).Select(item => new Computer
            {
                Codigo = item.Object.Codigo,
                Marca = item.Object.Marca,
                Specs = item.Object.Specs,
                Disponibilidad = item.Object.Disponibilidad,
                Id = item.Key
            }).ToList();
        }

        public async Task<List<Computer>> GetAllByCodigo(string codigo)
        {
            return (await firebaseClient.Child(nameof(Computer)).OnceAsync<Computer>()).Select(item => new Computer
            {
                Codigo = item.Object.Codigo,
                Marca = item.Object.Marca,
                Specs = item.Object.Specs,
                Disponibilidad = item.Object.Disponibilidad,
                Id = item.Key
            }).Where(c => c.Codigo.ToLower().Contains(codigo.ToLower())).ToList();
        }

        public async Task<Computer> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(Computer) + "/" + id).OnceSingleAsync<Computer>());
        }

       

        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(Computer) + "/" + id).DeleteAsync();
            return true;
        }

        



    }
}
