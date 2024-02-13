﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.DataAccess.Data;
using Vacation.DataAccess.IRepositories;
using Vacation.Models;

namespace Vacation.DataAccess.Repositories
{
    public class VacationRepository:Repository<Vacations>,IVacationRepository
    {
        private readonly ApplicationDbContext _db;
        public VacationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
