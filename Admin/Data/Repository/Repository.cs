using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Admin.Data.Repository
{
    public class Repository : IRepository
    {
        public AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        //Agregar nuevo empleado
        public void AddEmpleado(Empleado empleado)
        {
            _ctx.Empleados.Add(empleado);
        }
        //Listar empleados
        public List<Empleado> GetAllEmpleados()
        {
            return _ctx.Empleados.ToList();
        }
        //Obtener empleado
        public Empleado GetEmpleado(int id)
        {
            return _ctx.Empleados.FirstOrDefault(item => item.Id == id);
        }
        //Remover empleado
        public void RemoveEmpleado(int id)
        {
            _ctx.Empleados.Remove(GetEmpleado(id));
        }
        //Valida cambios
        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
        //Actualiza valores
        public void UpdateEmpleado(Empleado empleado)
        {
            _ctx.Empleados.Update(empleado);
        }
    }
}
