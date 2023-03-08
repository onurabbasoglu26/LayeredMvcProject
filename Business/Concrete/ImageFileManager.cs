using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageDal;

        public ImageFileManager(IImageFileDal imageDal)
        {
            _imageDal = imageDal;
        }

        public List<ImageFile> GetImageFileList()
        {
            return _imageDal.List();
        }
    }
}
