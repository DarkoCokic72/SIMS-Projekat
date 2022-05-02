using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace WpfApp1.Repo
{
    public class PhysicianRepository
    {
        public List<Physician> GetAll()
        {
            return physicianFileHandler.Read();
        }

        public FileHandler.PhysicianFileHandler physicianFileHandler;

        public PhysicianRepository(PhysicianFileHandler fileHandler)
        {
            physicianFileHandler = fileHandler;
        }

    }
}
