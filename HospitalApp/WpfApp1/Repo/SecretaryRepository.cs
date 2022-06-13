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
        public void EditSecretaryProfile(Secretary newSecretary)
        {
            List<Secretary> secretaries = GetAll();
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].UniquePersonalNumber == newSecretary.UniquePersonalNumber)
                {
                    secretaries[i].Name = newSecretary.Name;
                    secretaries[i].Surname = newSecretary.Surname;
                    secretaries[i].PhoneNumber = newSecretary.PhoneNumber;
                    secretaries[i].Email = newSecretary.Email;
                }
            }

            secretaryFileHandler.Save(secretaries);
        }

        public void ChangeSecretaryPassword(Secretary newSecretary)
        {
            List<Secretary> secretaries = GetAll();
            for (int i = 0; i < secretaries.Count; i++)
            {
                if (secretaries[i].UniquePersonalNumber == newSecretary.UniquePersonalNumber)
                {
                    secretaries[i].Password = newSecretary.Password;
                }
            }

            secretaryFileHandler.Save(secretaries);
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
        public SecretaryRepository() { }

        public SecretaryRepository(SecretaryFileHandler fileHandler)
        {
            secretaryFileHandler = fileHandler;
        }

    }
}
