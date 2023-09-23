﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;

namespace evdekinisatcom.MvcWebApp_App.Service.ViewModels
{
    public class UsersInOrOutRoleViewModel
    {
        public AppRole Role { get; set; }

        public List<AppUser> UsersInRole { get; set; }

        public List<AppUser> UsersOutRole { get; set; }
    }
}
