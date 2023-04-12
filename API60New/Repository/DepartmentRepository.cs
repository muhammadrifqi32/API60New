using API60New.Context;
using API60New.Models;
using API60New.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API60New.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MyContext myContext;
        public DepartmentRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int Id)
        {
            var findId = myContext.Departments.Find(Id);
            if (findId != null)
            {
                myContext.Departments.Remove(findId);
                return myContext.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Department> GetAll()
        {
            return myContext.Departments.ToList();
        }

        public Department GetById(int Id)
        {
            var getById = myContext.Departments.Find(Id);
            if (getById != null)
            {
                return getById;
            }
            return null;
        }

        public int Insert(Department department)
        {
            myContext.Departments.Add(department);
            var insert = myContext.SaveChanges();
            if (insert >= 1)
            {
                return insert;
            }
            return 0;
        }

        public int Update(Department department)
        {
            myContext.Entry(department).State = EntityState.Modified;
            var update = myContext.SaveChanges();
            if (update >= 1)
            {
                return update;
            }
            return 0;
        }
    }
}
