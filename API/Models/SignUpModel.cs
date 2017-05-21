using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class SignUpModel
    {
        AuthContext _cntx;

        public SignUpModel() {
            _cntx = new AuthContext();
        }

        public object GetSignUpModel()
        {
           return _cntx.Usuarios
                .Select(d => new {
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
            Usuario usr     = new Usuario();
            Cuenta  cnt     = new Cuenta(); 
            double  hours   = 48.00; 

            _cntx.Usuarios.Add(user);
            _cntx.SaveChanges();

            usr = _cntx.Usuarios
                .FirstOrDefault(w => w.Cedula == user.Cedula && w.Correo == user.Correo);

            cnt.IdUsuario = usr.Id;
            cnt.TokenActivacion = System.Guid.NewGuid().ToString().Replace("-","");
            cnt.TokenVencimiento = DateTime.Now.AddHours(hours);

            _cntx.Cuentas.Add(cnt);
            _cntx.SaveChanges();
            //Envio de correo electrónico
            SendMail(user);

            return _cntx.Usuarios
                .Where(w => w.Cedula == user.Cedula && w.Correo == user.Correo)
                .Select(d => new {
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

        public object PutSignUpModel(Usuario user)
        {

            Usuario usr = _cntx.Usuarios
                .FirstOrDefault(c => c.Id == user.Id);

            _cntx.Usuarios.Attach(usr);

            usr.Nombre = user.Nombre;
            usr.Apellidos = user.Apellidos;
            usr.Correo = user.Correo;

            _cntx.SaveChanges(); 

            object result = _cntx.Usuarios
                .Where(w => w.Id == user.Id)
                .Select(d => new {
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

        public void DeleteSignUpModel(Usuario user) {

            Usuario usr = _cntx.Usuarios
                .FirstOrDefault(c => c.Id == user.Id);

            _cntx.Usuarios.Remove(usr);
            _cntx.SaveChanges();
        }

        public void SendMail(Usuario user) {

            _cntx.Database.ExecuteSqlCommand("[MAIL].[NotificacionPreRegistroIndividual] @Id", 
                new SqlParameter("@Id", user.Cedula));
        }
    }
}