using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojKomisEMPTY.Models
{
    public interface ISamochodRepository
    {
        IEnumerable<Samochod> PobierzWszystkieSamochody();
        Samochod PobierzSamochodOID(int SamochodId);
        void DodajSamochod(Samochod samochod);
        void EdytujSamochod(Samochod samochod);
        void UsunSamochod(Samochod samochod);
    }
}
