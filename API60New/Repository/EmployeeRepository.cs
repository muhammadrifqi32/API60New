using API60New.Context;
using API60New.Models;
using API60New.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API60New.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(string NIK)
        {
            var findId = myContext.Departments.Find(NIK);
            if (findId != null)
            {
                myContext.Departments.Remove(findId);
                return myContext.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Employee> GetAll()
        {
            return myContext.Employees.ToList();
        }

        public Employee GetById(string NIK)
        {
            var getById = myContext.Employees.Find(NIK);
            if (getById != null)
            {
                return getById;
            }
            return null;
        }

        public int Insert(Employee employee)
        {
            myContext.Employees.Add(employee);
            var insert = myContext.SaveChanges();
            if (insert >= 1)
            {
                return insert;
            }
            return 0;
        }

        public int Update(Employee employee)
        {
            myContext.Entry(employee).State = EntityState.Modified;
            var update = myContext.SaveChanges();
            if (update >= 1)
            {
                return update;
            }
            return 0;
        }
    }
}
