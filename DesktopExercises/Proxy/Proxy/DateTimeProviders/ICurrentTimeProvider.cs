﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DateTimeProviders
{
    public interface ICurrentTimeProvider
    {
        DateTime CurrentTime();
    }
}
