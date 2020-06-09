using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Data.Repository
{
    public interface IRepository
    {
        Empleado GetEmpleado(int id);
        List<Empleado> GetAllEmpleados();
        void RemoveEmpleado(int id);
        void UpdateEmpleado(Empleado empleado);
        void AddEmpleado(Empleado empleado);
        Task<bool> SaveChangesAsync();

    }
}
