﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Data.Entity
{
    public class Onboarding : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Ordering { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
