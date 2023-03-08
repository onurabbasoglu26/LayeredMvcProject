using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        void AddWriter(Writer writer);
        void RemoveWriter(Writer writer);
        void UpdateWriter(Writer writer);
        Writer GetWriterById(int id);
    }
}
