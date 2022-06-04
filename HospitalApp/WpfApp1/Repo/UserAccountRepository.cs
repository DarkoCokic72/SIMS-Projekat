﻿using FileHandler;
using Model;
using Repo;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.FileHandler;
using WpfApp1.Model;

namespace WpfApp1.Repo
{
    public class UserAccountRepository
    {
        public List<UserAccount> GetAll()
        {
            return userAccountFileHandler.Read();
        }

        public UserAccount GetByEmailPassword(string email, string password)
        {
            UserAccount patient = IsUserPatient(email, password);
            UserAccount manager = IsUserManager(email, password);
            UserAccount secretary = IsUserSecretary(email, password);
            UserAccount physician = IsUserPhysician(email, password);
            if (patient != null) return patient;
            else if (manager != null) return manager;
            else if (secretary != null) return secretary;
            else if (physician != null) return physician;
            else
            {
                MessageBox.Show("BAD LOGIN!\nWrong email or password!", "Error");
                return null;
            }
        }

        public UserAccountFileHandler userAccountFileHandler = new UserAccountFileHandler();

        public UserAccountRepository() { }
        public UserAccountRepository(UserAccountFileHandler fileHandler)
        {
           userAccountFileHandler = fileHandler;
        }

        private UserAccount IsUserPatient(string email, string password)
        {
            PatientFileHandler patientFileHandler = new PatientFileHandler();
            PatientRepository patientRepository = new PatientRepository(patientFileHandler);
            foreach (UserAccount user in patientRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }

            }

            return null;
        }

        private UserAccount IsUserManager(string email, string password) 
        {
            ManagerFileHandler managerFileHandler = new ManagerFileHandler();
            ManagerRepository managerRepository = new ManagerRepository(managerFileHandler);
            foreach (UserAccount user in managerRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        private UserAccount IsUserSecretary(string email,string password)
        {
            SecretaryFileHandler secretaryFileHandler = new SecretaryFileHandler();
            SecretaryRepository secretaryRepository = new SecretaryRepository(secretaryFileHandler);
            foreach (UserAccount user in secretaryRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }

            }
            return null;
        }

        private UserAccount IsUserPhysician(string email, string password)
        {
            PhysicianFileHandler physicianFileHandler = new PhysicianFileHandler();
            PhysicianRepository physicianRepository = new PhysicianRepository();
            foreach (UserAccount user in physicianRepository.GetAll())
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

    }
}