using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class SignUpModel
    {
        AuthContext _cntx;

        public object HTTPStatusCode { get; private set; }

        public SignUpModel() {
            _cntx = new AuthContext();
        }

        public object GetSignUpModel()
        {
           return _cntx.Usuarios.Select(d => new
           {
               Id = d.Id,
               Cedula = d.Cedula,
               Nombre = d.Nombre,
               Apellidos = d.Apellidos,
               FechaNacimiento = d.FechaNacimiento,
               Correo = d.Correo,
               Direccion = d.Direccion,
               Movil = d.Movil,
               Telefono = d.Telefono
           }).ToList();
        }

        public object SetSignUpModel(Usuario user)
        {
            _cntx.Usuarios.Add(user);
            _cntx.SaveChanges();

            object result = _cntx.Usuarios.Where(w => w.Cedula == user.Cedula && w.Correo == user.Correo).Select(d => new
            {
                Id = d.Id,
                Cedula = d.Cedula,
                Nombre = d.Nombre,
                Apellidos = d.Apellidos,
                FechaNacimiento = d.FechaNacimiento,
                Correo = d.Correo,
                Direccion = d.Direccion,
                Movil = d.Movil,
                Telefono = d.Telefono
            }).ToList();

            return result;
        }

        public object PutSignUpModel(Usuario user)
        {

            Usuario usr = _cntx.Usuarios
                .FirstOrDefault(c => c.Id == user.Id);

            _cntx.Usuarios.Attach(usr);
            usr.Correo = user.Correo;
            _cntx.SaveChanges(); 

            object result = _cntx.Usuarios.Where(w => w.Id == user.Id).Select(d => new
            {
                Id = d.Id,
                Cedula = d.Cedula,
                Nombre = d.Nombre,
                Apellidos = d.Apellidos,
                FechaNacimiento = d.FechaNacimiento,
                Correo = d.Correo,
                Direccion = d.Direccion,
                Movil = d.Movil,
                Telefono = d.Telefono
            }).ToList();

            return result;

        }

        public void DeleteSignUpModel(int id) {

            Usuario usr = _cntx.Usuarios
                .FirstOrDefault(c => c.Id == id);

            _cntx.Usuarios.Remove(usr);
            _cntx.SaveChanges();
        }
    }
}