using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.App.Dominio;

namespace Veterinaria.App.Persistencia{

    public interface IRepositorioCita{

        Cita AgregarCita(Cita Cita);
        Cita EditarCita(Cita Cita);
        Cita GetCita(int idCita);
        void EliminarCita(int idCita);
        IEnumerable <Cita> GetCitas();


    }

}