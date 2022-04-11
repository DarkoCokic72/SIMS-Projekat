using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace WpfApp1.FileHandler
{
    public class OperationFileHandler
    {
        private string path = @"..\..\Data\OperationData";

        public List<Operation> Read()
        {
            //throw new NotImplementedException();

            string operationsSerialized = System.IO.File.ReadAllText(path);
            List<Operation> operations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Operation>>(operationsSerialized);
            return operations;
        }

        public void Write(List<Operation> operations)
        {
            //throw new NotImplementedException();
            string operationsSerialised = Newtonsoft.Json.JsonConvert.SerializeObject(operations);
            System.IO.File.WriteAllText(path, operationsSerialised);
        }

    }
}
