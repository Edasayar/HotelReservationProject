using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class MessageCategoryService : IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategorydal;

        public MessageCategoryService(IMessageCategoryDal messageCategoryDal)
        {
            _messageCategorydal = messageCategoryDal;
        }
        public void TDelete(MessageCategory t)
        {
            _messageCategorydal.Delete(t);
        }

        public MessageCategory TGetById(int id)
        {
            return _messageCategorydal.GetById(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategorydal.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            _messageCategorydal.Insert(t);
        }

        public void TUpdate(MessageCategory t)
        {
            _messageCategorydal.Update(t);
        }
    }
}
