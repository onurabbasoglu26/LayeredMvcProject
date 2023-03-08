using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddContent(Content content)
        {
            _contentDal.Insert(content);
        }

        public Content GetContentById(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetContentList()
        {
            return _contentDal.List();
        }

        public List<Content> GetContentList(string p)
        {
            return _contentDal.List(x => x.ContentValue.ToLower().Contains(p.ToLower()));
        }

        public List<Content> GetContentListWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public void RemoveContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public void UpdateContent(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
