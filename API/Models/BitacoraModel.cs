using API.DTO;
using DATA.Entities;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class BitacoraModel
    {
        AuthContext _cntx;

        public BitacoraModel()
        {
            _cntx = new AuthContext();
        }

        public object GetBitacora()
        {
            try 
            {
                //return _cntx.Bitacora.ToList();

                return _cntx.Bitacora.AsEnumerable().Select(c => new BitacoraDTO
                {
                    NombrePc = c.NombrePc,
                    Id = c.Id,
                    FechayHoraIngreso = c.FechayHoraIngreso,
                    FechayHoraSalida = c.FechayHoraSalida,
                    TipoLogin = Enum.GetName(typeof(TipoInicio), c.TipoInicio),
                    Token = c.Token,
                    UserName = c.UserName,

                }).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Error Cargando Lista Bitacora Completa " + ex.Message);
            }
        }


        public object GetBitacora(string Usuario) 
        {
            try
            {
                return _cntx.Bitacora.Where(c => c.UserName == Usuario).ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error Cargando Lista Bitacora por Usuario " + ex.Message);
            }
        }

        public object GetBitacora(Bitacora bitacora) 
        {
            try
            {
                List<Bitacora> listaBitacora = _cntx.Bitacora.Where(c => c.UserName == bitacora.UserName).ToList();


                if (bitacora.FechayHoraSalida != null)
                    listaBitacora = listaBitacora.Where(c => c.FechayHoraSalida == bitacora.FechayHoraSalida).ToList();

                if (bitacora.FechayHoraIngreso != null)
                    listaBitacora = listaBitacora.Where(c => c.FechayHoraIngreso == bitacora.FechayHoraIngreso).ToList();

                if (bitacora.TipoInicio != null)
                {
                    listaBitacora = listaBitacora.Where(c => c.TipoInicio == bitacora.TipoInicio).ToList();
                }

                return listaBitacora;
            }
            catch (Exception ex) {
                throw new Exception("Error Cargando Lista Bitacora por Filtros " + ex.Message);
            }
        }


        public void SetBitacora(Bitacora bitacora) 
        {
            try
            {
                Bitacora createBitacora = new Bitacora();

                createBitacora.FechayHoraIngreso = DateTime.Now;
                createBitacora.Token = bitacora.Token;
                createBitacora.NombrePc = bitacora.NombrePc;
                createBitacora.TipoInicio = bitacora.TipoInicio;
                createBitacora.UserName = bitacora.UserName;
                createBitacora.IpDispositivo = String.Empty;
                _cntx.Bitacora.Add(createBitacora);

                _cntx.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception("Error Guardando Bitacora " + ex.Message);
            }
            
        }


        public void PutBitacora(string Usuario) {
            try
            {

                //Consulta la ultima bitacora que este sin fecha de salida del usuario
                Bitacora updateBitacora = _cntx.Bitacora.OrderByDescending(c=> c.Id).FirstOrDefault(c => c.UserName == Usuario && c.FechayHoraSalida == null);
                
                
                if (updateBitacora != null)
                {
                    updateBitacora.FechayHoraSalida = DateTime.Now;
                    _cntx.SaveChanges();
                }

            }
            catch (Exception ex) 
            {
                throw new Exception("Erorr Cambiando Fecha de Finalizacion Bitacora " + ex.Message);
            }

        }



    }
}