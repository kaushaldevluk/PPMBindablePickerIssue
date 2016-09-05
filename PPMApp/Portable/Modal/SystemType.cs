﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable.Modal
{
    public class SystemType
    {
        [PrimaryKey, AutoIncrement]
        public int SystemTypeID { get; set; }
        public int SystemElementID { get; set; }
        public string SystemElementTypeName { get; set; }
        public DateTime createon { get; set; }
        public bool issupload { get; set; }
        public bool isedit { get; set; }
    }
}
