
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia{


    public class RepositorioDuenioMascota : IRepositorioDuenioMascota{

        private readonly AppContext appContext;  

        public RepositorioDuenioMascota(AppContext appContextParam){
            this.appContext = appContextParam;
        }

        // CRUD
        //Create
        DuenioMascota IRepositorioDuenioMascota.AgregarDuenioMascota(DuenioMascota duenioMascota) {
            var duenioMascotaAgregado = this.appContext.DuenioMascota.Add(duenioMascota);
            this.appContext.SaveChanges();
            return duenioMascotaAgregado.Entity;
        }

        //Update
        DuenioMascota IRepositorioDuenioMascota.EditarDuenioMascota(DuenioMascota duenioMascotaNuevo) {

            var duenioMascotaEncontrado = this.appContext.DueniosMascota.FirstOrDefault( p => p.Id == duenioMascotaNuevo.Id); 
            if(duenioMascotaEncontrado != null){
                duenioMascotaEncontrado.IdDuenioMascota = duenioMascotaNuevo.IdDuenioMascota;
                duenioMascotaEncontrado.Nombre = duenioMascotaNuevo.Nombre;
                duenioMascotaEncontrado.Telefono = duenioMascotaNuevo.Telefono;
                duenioMascotaEncontrado.Correo = duenioMascotaNuevo.Correo;                                
                this.appContext.SaveChanges();  
                return duenioMascotaEncontrado;              
            } else {
                return null;
            }          
        }

        //Read
         DuenioMascota IRepositorioDuenioMascota.GetDuenioMascota(int idDuenioMascota) {
            return this.appContext.DuenioMascota.FirstOrDefault( p => p.Id == idDuenioMascota);           
        }


        //Eliminate
        void DuenioMascota(int idDuenioMascota) {
           var duenioMascotaEncontrado = this.appContext.DuenioMascota.FirstOrDefault( p => p.Id == idDuenioMascota); 

            if(duenioMascotaEncontrado != null) {
                this.appContext.DuenioMascota.Remove(duenioMascotaEncontrado);
                this.appContext.SaveChanges();
            }

        }


        IEnumerable <DuenioMascota> IRepositorioDuenioMascota.GetDuenioMascotas(){
            return null;
        }



    }
}