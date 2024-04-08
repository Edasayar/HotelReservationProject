using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        
        int GetBookingCount();
        List<Booking> Last6BookingsList();
        void BookingStatusChangeApproved(int Id);
        void BookingStatusChangeCancel(int Id);
        void BookingStatusChangeWait(int Id);
    }
}
