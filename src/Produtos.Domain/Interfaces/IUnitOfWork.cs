using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces
{
    public interface IUnitOfWork
    {
          Task Commit();
    }
}