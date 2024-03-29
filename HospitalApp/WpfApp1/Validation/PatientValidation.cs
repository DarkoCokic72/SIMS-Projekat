﻿using Controller;
using FileHandler;
using Model;
using Repo;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Controller;
using WpfApp1.FileHandler;
using WpfApp1.Repo;
using WpfApp1.Service;

namespace WpfApp1.Validation
{
    public class UPNValidation : ValidationRule
    {
        public static bool ValidationError { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            UserAccountFileHandler userAccountFileHandler = new UserAccountFileHandler();
            UserAccountRepository userAccountRepository = new UserAccountRepository(userAccountFileHandler);
            UserAccountService userAccountService = new UserAccountService(userAccountRepository);
            UserAccountController userAccountController = new UserAccountController(userAccountService);

            ValidationError = false;
            var s = value as string;

            if (s.Length != 13) 
            {
                ValidationError = true;
                return new ValidationResult(false, "UPN must \nhave 13 \ncharacters");
            }

            else if (!Regex.IsMatch(s, @"[0-9]+"))
            {
                ValidationError = true;
                return new ValidationResult(false, "Wrong\nformat\nof UPN");
            }

            /*else if (userAccountController.UPNExists(s))
            {
             ValidationError = true;
             return new ValidationResult(false, "Taken UPN.\nYou must have \nmade a mistake");
             }
            */
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
