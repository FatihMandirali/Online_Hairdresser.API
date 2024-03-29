﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Models.Enums
{
    public enum ProcessStatusEnum
    {
        Undefined = 0,
        Success = 200,
        BadRequest = 400,
        AccessDenied = 403,
        NotFound = 404,
        AccountLocked = 423,
        InternalServerError = 500,
        Error = 501,
        MajorUpdate = 502,
        MinorUpdate = 503,
    }
}
