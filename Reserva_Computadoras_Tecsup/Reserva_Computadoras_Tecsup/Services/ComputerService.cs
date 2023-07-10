using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Computadoras_Tecsup.Services
{
    public class ComputerService
    {
        private FirebaseService firebaseService;

        public ComputerService()
        {
            firebaseService = new FirebaseService();
        }

        public async Task<IList<Models.Computer>> GetComputers()
        {
            return await firebaseService.GetComputers();
        }
    }
}
