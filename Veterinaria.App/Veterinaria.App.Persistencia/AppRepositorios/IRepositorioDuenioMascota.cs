
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.App.Dominio;

namespace Veterinaria.App.Persistencia{

    public interface IRepositorioDuenioMascota{

        DuenioMascota AgregarDuenioMascota(DuenioMascota duenioMascota);
        DuenioMascota EditarDuenioMascota(DuenioMascota duenioMascota);
        DuenioMascota GetDuenioMascota(int idDuenioMascota);
        void EliminarDuenioMascota(int idDuenioMascota);
        IEnumerable <DuenioMascota> GetDueniosMascota();


    }

}