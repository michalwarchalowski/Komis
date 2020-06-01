using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojKomisEMPTY.Models
{
    public class OpiniaRepository : IOpiniaRepository
    {
       private readonly AppDbContext _dbcontext;
        public OpiniaRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void DodajOpinie(Opinia opinia)
        {
            _dbcontext.Opinie.Add(opinia);
            _dbcontext.SaveChanges();
        }
    }
}
