using SeleniumWebDriverFirstTests.Models;
using System;
using System.Collections.Generic;
using System.IO;
using NPOI;
using System.Text;
using NPOI.SS.UserModel;

namespace SeleniumWebDriverFirstTests.Factories
{
    public static class UserFactory
    {
        public static RegistrationUser GenerateRegUser()
        {
            var _user = new RegistrationUser();
            _user.FirstName = "Ventsi";
            _user.LastName = "Ivanov";
            _user.MatrialStatus = new List<bool>() { false, true, false };
            _user.Hobbies = new List<bool>() { false, true, false };
            _user.Country = "Bulgaria";
            _user.Month = "3";
            _user.Day = "1";
            _user.Year = "1989";
            _user.Phone = "359999999999";
            _user.UserName = "HHHHHHHHHHHHHH";
            _user.Email = "fiwghiwghjv@fjhf.bfte";
            _user.PicturePath = Path.GetFullPath(@"..\..\..\logo.jpg");
            _user.Description = "Description";
            _user.Password = "ewfegtrwdg";
            _user.ConfirmPassword = "ewfegtrwdg";
            return _user;
        }
    }
}
