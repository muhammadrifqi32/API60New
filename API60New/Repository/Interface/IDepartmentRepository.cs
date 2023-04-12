using API60New.Models;

namespace API60New.Repository.Interface
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();
        public Department GetById(int Id);
        public int Insert(Department department);
        public int Update(Department department);
        public int Delete(int Id);
    }
}
