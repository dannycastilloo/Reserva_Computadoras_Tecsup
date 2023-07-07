using System.Collections.Generic;

namespace Reserva_Computadoras_Tecsup.Repositories
{
    public interface IFirestoreRepository<T>
    {
        T Get(T record);
    }
}
