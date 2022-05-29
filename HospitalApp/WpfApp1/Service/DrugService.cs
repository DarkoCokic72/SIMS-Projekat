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

        public void Create(Drug drug)
        {
            drugRepository.Create(drug);
        }

        public void Update(Drug drug)
        {
            drugRepository.Update(drug);
        }

        public bool DrugExists(string drugName, string oldDrugName)
        {
            return drugRepository.DrugExists(drugName, oldDrugName);
        }
        public DrugRepository drugRepository = new DrugRepository();
    }
}
