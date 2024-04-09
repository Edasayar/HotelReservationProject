using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal: GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {

        }

     

      

        public void BookingStatusChangeApproved(int Id)
        {
            var context = new Context();
            var values = context.Bookings.Find(Id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int Id)
        {
            var context = new Context();
            var values = context.Bookings.Find(Id);
            values.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWait(int Id)
        {
            var context = new Context();
            var values = context.Bookings.Find(Id);
            values.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public List<Booking> GetApprovedBookings()
        {
            var context = new Context();
            return context.Bookings.Where(b => b.Status == "Onaylandı").ToList();
        }

        public int GetBookingCount()
        {
            var context = new Context();
            var value = context.Bookings.Count();
            return value;
        }

        public List<Booking> GetCancelledBookings()
        {
            var context = new Context();
            return context.Bookings.Where(b => b.Status == "İptal Edildi").ToList();
        }

        public List<Booking> GetWaitBookings()
        {
            var context = new Context();
            return context.Bookings.Where(b => b.Status == "Müşteri Aranacak").ToList();
        }

        public List<Booking> Last6BookingsList()
        {
            var context = new Context();
            var values = context.Bookings.OrderByDescending(x=>x.BookingId).Take(6).ToList();
            return values;
        }
    }
}
