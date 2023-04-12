using API60New.Models;

namespace API60New.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll();
        public Employee GetById(string NIK);
        public int Insert(Employee employee);
        public int Update(Employee employee);
        public int Delete(string NIK);
    }
}
