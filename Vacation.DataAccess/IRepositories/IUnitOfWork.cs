﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.DataAccess.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IDepartmentRepository Department { get; }
        public IVacationRepository Vacation { get; }

    }
}
