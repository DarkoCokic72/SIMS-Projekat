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
    public class SecretaryRepository
    {
        public List<Secretary> GetAll()
        {
            return secretaryFileHandler.Read();
        }
        public bool UPNExists(string upn)
        {
            foreach (Secretary secretary in GetAll())
            {
                if (secretary.UniquePersonalNumber == upn) return true;
            }
            return false;
        }
        public bool EmailExists(string email)
        {
            foreach (Secretary secretary in GetAll())
            {
                if (secretary.Email == email) return true;
            }
            return false;
        }

        public FileHandler.SecretaryFileHandler secretaryFileHandler;

        public SecretaryRepository(SecretaryFileHandler fileHandler)
        {
            secretaryFileHandler = fileHandler;
        }

    }
}
