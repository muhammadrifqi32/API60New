using API60New.Context;
using API60New.Models;
using API60New.Repository.Interface;
using API60New.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API60New.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public class CheckConstants
        {
            public const int successful = 1;
            public const int phoneExists = 2;
            public const int emailExists = 3;
        }
        

        public int Register(RegisterVM registerVM)
        {
            Employee employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Phone = registerVM.Phone,
                BirthDate = registerVM.BirthDate,
                Salary = registerVM.Salary,
                Email = registerVM.Email,
                Gender = (Gender)registerVM.Gender,
                Department_Id = registerVM.Department_Id,
            };
            myContext.Employees.Add(employee);
            Account account = new Account
            {
                NIK = employee.NIK,
                Password = registerVM.Password
            };
            myContext.Accounts.Add(account);
            return myContext.SaveChanges();
        }

        public IEnumerable<Account> GetAll()
        {
            return myContext.Accounts.ToList();
            //var get = myContext.Employees.Include("Departments").Include("Account").ToList().Select(r => new
            //{
            //   r.FirstName,
            //   r.LastName,
            //   r.Phone,
            //   r.BirthDate,
            //   r.Salary,
            //   r.Email,
            //   r.Gender,
            //   r.Department_Id
            //});
            //return get;

        }
    }
}
