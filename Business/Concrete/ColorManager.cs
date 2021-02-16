using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessDataResult<Color>(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessDataResult<Color>(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
           
            return new SuccessDataResult<Color>( _colorDal.Get(p => p.ColorId==colorId),Messages.ColorsListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessDataResult<Color>(Messages.ColorUpdated);
        }
    }
}
