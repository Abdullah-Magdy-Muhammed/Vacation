using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.DataAccess.Data;
using Vacation.DataAccess.IRepositories;
using Vacation.Models;

namespace Vacation.DataAccess.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
