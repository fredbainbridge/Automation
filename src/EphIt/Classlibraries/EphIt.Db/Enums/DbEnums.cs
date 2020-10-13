﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EphIt.Db.Enums
{

    public enum ScriptLanguageEnum : short
    {
        PowerShell5 = 1
    }


    public enum RBACObjectsId : short
    {
        Scripts = 1,
        Roles = 2,
        Variables = 3,
        Modules = 4,
        Jobs = 5
    }
}
