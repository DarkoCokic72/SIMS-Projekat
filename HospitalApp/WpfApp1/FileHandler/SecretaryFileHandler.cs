/***********************************************************************
 * Module:  SecretaryFileHandler.cs
 * Author:  smvul
 * Purpose: Definition of the Class FileHandler.SecretaryFileHandler
 ***********************************************************************/

using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.FileHandler

{
    public class SecretaryFileHandler
{

    public List<Secretary> Read()
    {

        if (!System.IO.File.Exists(path))
        {
            return new List<Secretary>();
        }

        string secretarySerialized = System.IO.File.ReadAllText(path);
        List<Secretary> secretary = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Secretary>>(secretarySerialized);
        return secretary;
    }

    public void Save(List<Secretary> secretary)
    {
        string secretarySerialized = Newtonsoft.Json.JsonConvert.SerializeObject(secretary);
        System.IO.File.WriteAllText(path, secretarySerialized);
    }

    private string path = @"..\..\Data\Secretaries.txt";
}
}