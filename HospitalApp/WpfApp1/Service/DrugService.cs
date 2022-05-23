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

        public bool Update(Drug drug, string oldNameOfDrug)
        {
            return drugRepository.Update(drug, oldNameOfDrug);
        }

        public bool DrugExists(string drugName)
        {
            return drugRepository.DrugExists(drugName);
        }
        public DrugRepository drugRepository = new DrugRepository();
    }
}
