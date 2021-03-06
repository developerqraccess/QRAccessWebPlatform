﻿using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
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
            int tipoUsuario = 4;                        //Tipo Usuario (4 = funcionario) 
            int est         = 1;                        //Estado de la cuenta (Inactiva)
            _cntx.Usuarios.Add(user);
            _cntx.SaveChanges();

            usr = _cntx.Usuarios
                .FirstOrDefault(w => w.Cedula == user.Cedula && w.Correo == user.Correo);

            cnt.IdUsuario = usr.Id;
            cnt.Tipo = tipoUsuario;
            cnt.Estado = est;
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

            Cuenta cnt = _cntx.Cuentas.FirstOrDefault(c => c.IdUsuario == usr.Id);

            _cntx.Cuentas.Remove(cnt);
            _cntx.Usuarios.Remove(usr);
            _cntx.SaveChanges();
        }

        public void SendMail(Usuario user) {

            _cntx.Database.ExecuteSqlCommand("[MAIL].[NotificacionPreRegistroIndividual] @Id", 
                new SqlParameter("@Id", user.Cedula));
        }

        public bool ValidateAccountToken(string Token) {
            Cuenta cnt = _cntx.Cuentas
                .FirstOrDefault(w => w.TokenActivacion == Token);

            if (cnt.TokenVencimiento > DateTime.Now)
                return true;
            else
                return false;
        }

        public object GetUserInformation(string Token) {

            return _cntx.Usuarios.
            Join(_cntx.Cuentas, u => u.Id, c => c.IdUsuario,
            (u, c) => new { u, c })
            .Where(m => m.c.TokenActivacion == Token)
            .Select(m => new
            {
                IdUsuario = m.u.Id,
                Cedula = m.u.Cedula,
                Nombre = m.u.Nombre,
                Apellidos = m.u.Apellidos,
                FechaNacimiento = (m.u.FechaNacimiento.HasValue) ?
                    SqlFunctions.DateName("yyyy",m.u.FechaNacimiento) + "-" +
                    SqlFunctions.StringConvert((double)m.u.FechaNacimiento.Value.Month).TrimStart() + "-" +
                    SqlFunctions.DateName("dd",m.u.FechaNacimiento) :
                    string.Empty,
                Correo = m.u.Correo,
                Direccion = m.u.Direccion,
                Movil = m.u.Movil,
                Telefono = m.u.Telefono,
                IdCuenta = m.c.Id,
                NombreUsuario = m.c.NombreUsuario,
                Tipo = m.c.Tipo,
                Estado = m.c.Estado,
                FechaRegistro = m.c.FechaRegistro,
                FechaVencimiento = m.c.FechaVencimiento,
                TokenActivacion = m.c.TokenActivacion,
                TokenVencimiento = m.c.TokenVencimiento

            }).ToList();

        }

        public void SetUserInformation(Usuario elem) {

            Usuario usr = _cntx.Usuarios
                .FirstOrDefault(c => c.Id == elem.Id);

            _cntx.Usuarios.Attach(usr);

            usr.Nombre = elem.Nombre;
            usr.Apellidos = elem.Apellidos;
            usr.FechaNacimiento = elem.FechaNacimiento;
            usr.Correo = elem.Correo;
            usr.Direccion = elem.Direccion;
            usr.Telefono = elem.Telefono;
            usr.Movil = elem.Movil;

            _cntx.SaveChanges();

        }

        public void SetAccountInformation(Cuenta elem) {
            int est = 2;                        //Estado de la cuenta (Activa)
            DateTime fechReg = DateTime.Now;    //Fecha de registro (Ahora)

            Cuenta cnt = _cntx.Cuentas
                .FirstOrDefault(c => c.Id == elem.Id);

            _cntx.Cuentas.Attach(cnt);
            cnt.NombreUsuario = elem.NombreUsuario;
            cnt.Contrasena = elem.Contrasena;
            cnt.FechaRegistro = fechReg;
            cnt.Estado = est;
            _cntx.SaveChanges();
        }
    }
}       