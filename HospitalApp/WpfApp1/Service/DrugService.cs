using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repo;

namespace WpfApp1.Service
{
    public class DrugService
    {
        public List<Drug> GetAll()
        {
            return drugRepository.GetAll();
        }

        public bool Create(Drug drug)
        {
            return drugRepository.Create(drug);
        }

        public DrugRepository drugRepository = new DrugRepository();
    }
}
