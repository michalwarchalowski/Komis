using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojKomisEMPTY.Models
{
    public class MockSamochodRepository : ISamochodRepository
    {
        private List<Samochod> samochody;
        public Samochod PobierzSamochodOID(int SamochodId)
        {
            return samochody.FirstOrDefault(x => x.Id == SamochodId);
        }
        public MockSamochodRepository()
        {
            if (samochody == null)
            {
                ZaładujWszystkieSamochody();
            }
        }

        private void ZaładujWszystkieSamochody()
        {
            samochody = new List<Samochod> {
               new Samochod {Id=1,Cena=12345,JestSamochodemTygodnia=true,JestWCentrali=true,Marka="Opel",Moc="123",Model="Vectra",Opis="Moj Opelek", Pojemnosc="123",Przebieg="!2345",RodzajPaliwa="LPG",RokProdukcji=2002,MiniaturkaUrl="/Images/nissan.jpg",ZdjecieUrl="/Images/nissan.jpg" },
                              new Samochod {Id=1,Cena=12345,JestSamochodemTygodnia=true,JestWCentrali=true,Marka="Opel",Moc="123",Model="Vectra",Opis="Moj Opelek", Pojemnosc="123",Przebieg="!2345",RodzajPaliwa="LPG",RokProdukcji=2002,MiniaturkaUrl="/Images/Vectra.jpg",ZdjecieUrl="/Images/Vectra.jpg" }
           };
        }

        public IEnumerable<Samochod> PobierzWszystkieSamochody()
        {
            return samochody;
        }

        public void DodajSamochod(Samochod samochod)
        {
            throw new NotImplementedException();
        }

        public void EdytujSamochod(Samochod samochod)
        {
            throw new NotImplementedException();
        }

        public void UsunSamochod(Samochod samochod)
        {
            throw new NotImplementedException();
        }
    }
}
