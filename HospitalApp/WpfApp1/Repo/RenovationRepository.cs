﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace Repo
{
    public class RenovationRepository
    {
        public List<Renovation> GetAll()
        {
            return renovationFileHandler.Read();
        }

        public void Create(Renovation renovation)
        {

            List<Renovation> renovationList = renovationFileHandler.Read();
            renovationList.Add(renovation);
            renovationFileHandler.Save(renovationList);

        }

        public FileHandler.RenovationFileHandler renovationFileHandler = new FileHandler.RenovationFileHandler();

    }
}