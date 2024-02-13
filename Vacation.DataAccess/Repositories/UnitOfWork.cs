using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vacation.DataAccess.Data;
using Vacation.DataAccess.IRepositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Vacation.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IDepartmentRepository Department { get; }
        public IVacationRepository Vacation { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           
            Department = new DepartmentRepository(_db);
            Vacation = new VacationRepository(_db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }

}
