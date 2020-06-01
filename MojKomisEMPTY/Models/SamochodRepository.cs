using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojKomisEMPTY.Models
{
    public class SamochodRepository : ISamochodRepository
    {
        private readonly AppDbContext _dbcontext;
        public SamochodRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void DodajSamochod(Samochod samochod)
        {
            _dbcontext.Add(samochod);
            _dbcontext.SaveChanges();
        }

        public void EdytujSamochod(Samochod samochod)
        {
            _dbcontext.Update(samochod);
            _dbcontext.SaveChanges();
        }

        public Samochod PobierzSamochodOID(int SamochodId)
        {
            return _dbcontext.Samochody.Where(x => x.Id == SamochodId).FirstOrDefault();
        }

        public IEnumerable<Samochod> PobierzWszystkieSamochody()
        {
            return _dbcontext.Samochody;
        }

        public void UsunSamochod(Samochod samochod)
        {
            _dbcontext.Remove(samochod);
            _dbcontext.SaveChanges();
        }
    }
}
