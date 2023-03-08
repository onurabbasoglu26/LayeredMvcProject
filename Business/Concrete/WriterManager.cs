using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void AddWriter(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public Writer GetWriterById(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetWriterList()
        {
            return _writerDal.List();
        }

        public void RemoveWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
