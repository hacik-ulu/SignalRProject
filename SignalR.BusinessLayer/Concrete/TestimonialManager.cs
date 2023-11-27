using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimionalDal _testimonialDal;

        public TestimonialManager(ITestimionalDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimional entity)
        {
            _testimonialDal.Add(entity);
        }

        public void TDelete(Testimional entity)
        {
            _testimonialDal.Delete(entity);
        }

        public Testimional TGetById(int id)
        {
           return _testimonialDal.GetById(id);
        }

        public List<Testimional> TGetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public void TUpdate(Testimional entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
