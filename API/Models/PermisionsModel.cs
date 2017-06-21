using API.DTO;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PermisionsModel
    {
        AuthContext _cntx;

        public PermisionsModel()
        {
            _cntx = new AuthContext();
        }


        public object GetPermisions()
        {
            return _cntx.Permisos
                 .Select(d => new
                 {
                    Activo= d.Activo,
                    ID= d.ID,
                    Pantalla = d.Pantalla,
                     UrlPantalla =d.UrlPantalla
                 }).ToList();
        }



        public object GetPermisionsForUsers(Usuario user)
        {
            var a = _cntx.PermisosXUsuario.Where(c=> c.Usuarios.Id == user.Id).Select(c=> new PermisosUsuarioDTO {
                Crear = c.Crear,
                Editar = c.Editar,
                Eliminar = c.Eliminar,
                ID= c.ID,
                NombrePermiso = c.Permisos.Pantalla,
                URl = c.Permisos.UrlPantalla,
                Visualizar= c.Visualizar,
                NombreUsuario = c.Usuarios.Correo,
                
            }).ToList();
        
            if( a.Count > 0)
                return a ;
            else
            {
                CrearPermisosIniciales(user);
                return a = _cntx.PermisosXUsuario.Where(c => c.Usuarios.Id == user.Id).Select(c => new PermisosUsuarioDTO
                {
                    Crear = c.Crear,
                    Editar = c.Editar,
                    Eliminar = c.Eliminar,
                    ID = c.ID,
                    NombrePermiso = c.Permisos.Pantalla,
                    URl = c.Permisos.UrlPantalla,
                    Visualizar = c.Visualizar,
                    NombreUsuario = c.Usuarios.Correo,
                }).ToList();
            }

        }

        public object PutPermisionsForUser(PermisosUsuarioDTO permision) 
        {
            PermisosXUsuario permiso = _cntx.PermisosXUsuario.FirstOrDefault(c => c.ID == permision.ID);

            _cntx.PermisosXUsuario.Attach(permiso);
             permiso.Visualizar = permision.Visualizar;
            _cntx.SaveChanges();


            return _cntx.PermisosXUsuario.Where(c => c.ID == permision.ID).Select(c => new PermisosUsuarioDTO
            {
                Crear = c.Crear,
                Editar = c.Editar,
                Eliminar = c.Eliminar,
                ID = c.ID,
                NombrePermiso = c.Permisos.Pantalla,
                Visualizar = c.Visualizar,
                NombreUsuario = c.Usuarios.Correo,
            }).ToList();
        }

        public void CrearPermisosIniciales(Usuario user)
        {   
              List<Permisos> listaPermisos = _cntx.Permisos.ToList();

            foreach(Permisos permiso in listaPermisos)
            {
                PermisosXUsuario permisousuario = new PermisosXUsuario();
                permisousuario.Eliminar = false;
                permisousuario.Editar = false;
                permisousuario.Visualizar = false;
                permisousuario.Crear = false;
                permisousuario.Usuarios = user;
                permisousuario.Permisos = permiso;

                _cntx.PermisosXUsuario.Add(permisousuario);
                _cntx.SaveChanges();
            }
                
        }

    }

    }
