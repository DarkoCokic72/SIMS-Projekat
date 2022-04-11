using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using FileHandler;
using WpfApp1.FileHandler;

namespace Repo
{
    public class OperationRepository
    {
        public List<Operation> GetAll()
        {
            // throw new NotImplementedException();

            return operationFileHandler.Read();
        }

        public Operation GetById(string id)
        {
            //throw new NotImplementedException();
            List<Operation> listOfOperations = GetAll();
            foreach (Operation o in listOfOperations) {
                if (o.Id.Equals(id)) {
                    return o;
                }
            }

            return null;
        }

        public void Add(Operation operation)
        {
            // throw new NotImplementedException();
            if (GetById(operation.Id) == null)
            {
                List<Operation> listOfOperations = GetAll();
                listOfOperations.Add(operation);
                operationFileHandler.Write(listOfOperations);
            }
        }

        public void Update(Operation operation)
        {
            //throw new NotImplementedException();

            List<Operation> listOfOperations = GetAll();

            for (int i = 0; i < listOfOperations.Count; i++) { 
                
            }
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();
            List<Operation> listOfOperations = GetAll();

            for (int i = 0; i < listOfOperations.Count; i++) {
                if (listOfOperations[i].Equals(id))
                {
                    listOfOperations.Remove(listOfOperations[i]);
                }
            }

            operationFileHandler.Write(listOfOperations);
        }

        public OperationFileHandler operationFileHandler;

        public OperationRepository(OperationFileHandler fileHandler) {
            operationFileHandler = fileHandler;
        }

    }
}
