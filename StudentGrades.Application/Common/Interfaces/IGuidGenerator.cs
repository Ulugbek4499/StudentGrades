﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades.Application.Common.Interfaces
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }

}