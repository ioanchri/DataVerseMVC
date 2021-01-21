﻿using System;
using System.Collections.Generic;
using System.Text;
using Dataverse_Web_Project.Models;

namespace Dataverse_Web_Project.Options
{
    public class CustomerOption
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}
