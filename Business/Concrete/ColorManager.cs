using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;



namespace Business.Concrete
{
    class ColorManager : IColorService
    
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }
    }
}
