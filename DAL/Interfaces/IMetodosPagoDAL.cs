﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMetodosPagoDAL : IDALGenerico<MetodosPago>
    {
        List<MetodosPago> Get();

    }
}