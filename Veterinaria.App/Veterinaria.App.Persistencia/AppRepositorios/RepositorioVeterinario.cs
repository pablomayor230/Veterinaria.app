using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia{


    public class RepositorioVeterinario : IRepositorioVeterinario{

        private readonly AppContext appContext;  

        public RepositorioVeterinario(AppContext appContextParam){
            this.appContext = appContextParam;
        }
        
        // CRUD
        //Create
       Veterinario IRepositorioVeterinario.AgregarVeterinario(Veterinario veterinario) {
            var veterinarioAgregado = this.appContext.Veterinarios.Add(veterinario);
            this.appContext.SaveChanges();
            return veterinarioAgregado.Entity;
        }
        
        //Update
        Veterinario IRepositorioVeterinario.EditarVeterinario(Veterinario veterinarioNuevo) {

            var veterinarioEncontrado = this.appContext.Veterinarios.FirstOrDefault( p => p.Id == veterinarioNuevo.Id); 
            if(veterinarioEncontrado != null){
                veterinarioEncontrado.IdVeterinario = veterinarioNuevo.IdVeterinario;
                veterinarioEncontrado.Nombre = veterinarioNuevo.Nombre;
                veterinarioEncontrado.Telefono = veterinarioNuevo.Telefono;
                veterinarioEncontrado.Correo = veterinarioNuevo.Correo;  
                veterinarioEncontrado.Especializacion = veterinarioNuevo.Especializacion;
                veterinarioEncontrado.TarjetaProfesional = veterinarioNuevo.TarjetaProfesional;                              
                this.appContext.SaveChanges();  
                return veterinarioEncontrado;              
            } else {
                return null;
            }          
        }

        //Read
        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario) {
            return this.appContext.Veterinarios.FirstOrDefault( p => p.Id == idVeterinario);           
        }


        //Eliminate
        void IRepositorioVeterinario.EliminarVeterinario(int idVeterinario) {
           var veterinarioEncontrado = this.appContext.Veterinarios.FirstOrDefault( p => p.Id == idVeterinario); 

            if(veterinarioEncontrado != null) {
                this.appContext.Veterinarios.Remove(veterinarioEncontrado);
                this.appContext.SaveChanges();
            }

        }


        IEnumerable <Veterinario> IRepositorioVeterinario.GetVeterinarios(){
            return null;
        }



    }
}