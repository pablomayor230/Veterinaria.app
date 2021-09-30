
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.App.Persistencia{


    public class RepositorioCitas : IRepositorioCitas{

        private readonly AppContext appContext;  

        public RepositorioCita(AppContext appContextParam){
            this.appContext = appContextParam;
        }

        // CRUD

        Cita IRepositorioCitas.AgregarCita(Cita Cita) {
            var CitaAgregado = this.appContext.Citas.Add(Cita);
            this.appContext.SaveChanges();
            return CitaAgregado.Entity;
        }

        
        Cita IRepositorioCitas.EditarCita(Cita CitaNuevo) {

            var CitaEncontrada = this.appContext.Citas.FirstOrDefault( p => p.Id == CitaNuevo.Id); 
            if(CitaEncontrada != null){
                CitaEncontrada.Fecha = CitaNuevo.Fecha;
                CitaEncontrada.Triage = CitaNuevo.Triage;
                this.appContext.SaveChanges();  
                return CitaEncontrada;              
            } else {
                return null;
            }          
        }


         Cita IRepositorioCitas.GetCita(int idCita) {
            return this.appContext.Citas.FirstOrDefault( p => p.Id == idCita);           
        }



        void IRepositorioCitas.EliminarCita(int idCita) {
           var CitaEncontrada = this.appContext.Citas.FirstOrDefault( p => p.Id == idCita); 

            if(CitaEncontrada != null) {
                this.appContext.Citas.Remove(CitaEncontrada);
                this.appContext.SaveChanges();
            }

        }


        IEnumerable <Cita> IRepositorioCitas.GetCita(){
            return null;
        }



    }
}