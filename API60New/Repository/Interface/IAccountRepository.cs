using API60New.Models;
using API60New.ViewModels;

namespace API60New.Repository.Interface
{
    public interface IAccountRepository
    {
        public int Register(RegisterVM registerVM);
        public IEnumerable<Account> GetAll();
    }
}
