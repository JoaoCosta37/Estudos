﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.DateTimeProviders
{
    public interface ICurrentTimeProvider
    {
        DateTime CurrentTime();
    }
}
