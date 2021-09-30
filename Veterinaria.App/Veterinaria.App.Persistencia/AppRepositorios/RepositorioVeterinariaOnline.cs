using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia{


    public class RepositorioVeterinariaOnline : IRepositorioVeterinariaOnline{

        private readonly AppContext appContext;  

        public RepositorioVeterinariaOnline(AppContext appContextParam){
            this.appContext = appContextParam;
        }
        
        // CRUD
        //Create
       VeterinaraOnline IRepositorioVeterinariaOnline.AgregarVeterinaraOnline(VeterinariaOnline veterinaraOnline) {
            var veterinaraOnlineAgregada = this.appContext.VeterinaraOnline.Add(veterinaraOnline);
            this.appContext.SaveChanges();
            return veterinaraOnlineAgregada.Entity;
        }
        
        //Update
        VeterinaraOnline IRepositorioVeterinariaOnline.EditarVeterinaraOnline(VeterinaraOnline veterinaraOnlineNuevo) {

            var veterinaraOnlineEncontrado = this.appContext.VeterinaraOnline.FirstOrDefault( p => p.Id == veterinaraOnlineNuevo.Id); 
            if(veterinaraOnlineEncontrado != null){
                veterinaraOnlineEncontrado.IdVeterinaraOnline = veterinaraOnlineNuevo.IdVeterinaraOnline;
                veterinaraOnlineEncontrado.NumDocVeterinaraOnline = veterinaraOnlineNuevo.NumDocVeterinaraOnline;
                veterinaraOnlineEncontrado.Nombre = veterinaraOnlineNuevo.Nombre;
                veterinaraOnlineEncontrado.Telefono = veterinaraOnlineNuevo.Telefono;
                veterinaraOnlineEncontrado.Correo = veterinaraOnlineNuevo.Correo;  
                veterinaraOnlineEncontrado.Especializacion = veterinaraOnlineNuevo.Especializacion;
                veterinaraOnlineEncontrado.TarjetaProfesional = veterinaraOnlineNuevo.TarjetaProfesional;                              
                this.appContext.SaveChanges();  
                return veterinaraOnlineEncontrado;              
            } else {
                return null;
            }          
        }

        //Read
        VeterinaraOnline IRepositorioVeterinariaOnline.GetVeterinaraOnline(int idVeterinaraOnline) {
            return this.appContext.VeterinaraOnline.FirstOrDefault( p => p.Id == idVeterinaraOnline);           
        }


        //Eliminate
        void IRepositorioVeterinariaOnline.EliminarVeterinaraOnline(int idVeterinaraOnline) {
           var veterinaraOnlineEncontrado = this.appContext.VeterinaraOnline.FirstOrDefault( p => p.Id == idVeterinaraOnline); 

            if(veterinaraOnlineEncontrado != null) {
                this.appContext.VeterinaraOnline.Remove(veterinaraOnlineEncontrado);
                this.appContext.SaveChanges();
            }

        }


        IEnumerable <VeterinaraOnline> IRepositorioVeterinariaOnline.GetVeterinaraOnline(){
            return null;
        }



    }
}