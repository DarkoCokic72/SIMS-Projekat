using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Controller
{
    public class OperationContoler
    {
        public List<Operation> GetAll()
        {
            // throw new NotImplementedException();
            return operationService.GetAll();
        }

        public Operation GetByID(string id)
        {
            // throw new NotImplementedException();
            return operationService.GetByID(id);
        }

        public void Add(Operation operation)
        {
            //throw new NotImplementedException();
            operationService.Add(operation);
        }

        public void Update(Operation operation)
        {
            //throw new NotImplementedException();
            operationService.Update(operation);
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();
            operationService.Delete(id);
        }

        public Service.OperationService operationService;

        public OperationContoler(OperationService service)
        {
            this.operationService = service;
        }

    }
}
