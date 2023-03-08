using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList();
        List<Content> GetContentList(string p);
        List<Content> GetContentListWriter(int id);
        List<Content> GetListByHeadingId(int id);
        Content GetContentById(int id);
        void AddContent(Content content);
        void RemoveContent(Content content);
        void UpdateContent(Content content);
    }
}
