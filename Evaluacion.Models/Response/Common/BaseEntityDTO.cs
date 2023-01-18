﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Models.Response.Common
{
    public class BaseEntityDTO
    {
        public Guid Id { get; set; }

        public DateTime FechaCreacion { get; set; }

        public byte? Estado { get; set; }
    }
}