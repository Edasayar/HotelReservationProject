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
    public class BookingService : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingService(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

      

       

        public void TBookingStatusChangeApproved(int Id)
        {
            _bookingDal.BookingStatusChangeApproved(Id);
        }

        public void TBookingStatusChangeCancel(int Id)
        {
            _bookingDal.BookingStatusChangeCancel(Id);
        }

        public void TBookingStatusChangeWait(int Id)
        {
            _bookingDal.BookingStatusChangeWait(Id);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public List<Booking> TGetApprovedBookings()
        {
            return _bookingDal.GetApprovedBookings();   
        }

        public int TGetBookingCount()
        {
           return _bookingDal.GetBookingCount();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> TGetCancelledBookings()
        {
            return _bookingDal.GetCancelledBookings();
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public List<Booking> TGetPendingBookings()
        {
            return _bookingDal.GetPendingBookings();
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public List<Booking> TLast6BookingsList()
        {
            return _bookingDal.Last6BookingsList();
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }
    }
}
