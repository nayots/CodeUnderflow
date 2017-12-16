using CodeUnderflow.Services.Contracts;
using CodeUnderflow.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Services
{
    public class UserService : IUserService
    {
        private CodeUnderflowDbContext db;

        public UserService(CodeUnderflowDbContext db)
        {
            this.db = db;
        }
    }
}