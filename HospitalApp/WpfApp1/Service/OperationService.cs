using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repo;

namespace Service
{
    public class OperationService
    {
        public List<Operation> GetAll()
        {
            //throw new NotImplementedException();
            return operationRepository.GetAll();
        }

        public Operation GetByID(string id)
        {
            //throw new NotImplementedException();
            return operationRepository.GetById(id);
        }

        public void Add(Operation operation)
        {
            //throw new NotImplementedException();
            operationRepository.Add(operation);
        }

        public void Update(Operation operation)
        {
            //throw new NotImplementedException();
            operationRepository.Update(operation);
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();
            operationRepository.Delete(id);
        }

        public Repo.OperationRepository operationRepository;

        public OperationService(OperationRepository repo)
        {
            this.operationRepository = repo;
        }

    }
}
