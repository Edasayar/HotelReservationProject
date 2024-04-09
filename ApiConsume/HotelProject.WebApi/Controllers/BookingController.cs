using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int Id)
        {
            var values = _bookingService.TGetById(Id);
            _bookingService.TDelete(values);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int Id)
        {
            var values = _bookingService.TGetById(Id);
            return Ok(values);
        }

        

      

        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var values=_bookingService.TLast6BookingsList();
            return Ok(values);
        }

        [HttpGet("BookingAproved")]
        public IActionResult BookingAproved(int Id)
        {
            _bookingService.TBookingStatusChangeApproved(Id);
            return Ok();
        }

        [HttpGet("BookingCancel")]
        public IActionResult BookingCancel(int Id)
        {
            _bookingService.TBookingStatusChangeCancel(Id);
            return Ok();
        }

        [HttpGet("BookingWait")]
        public IActionResult BookingWait(int Id)
        {
            _bookingService.TBookingStatusChangeWait(Id);
            return Ok();
        }

        [HttpGet("BookingApprovedList")]
        public IActionResult BookingApprovedList()
        {
            var values = _bookingService.TGetApprovedBookings();
            return Ok(values);
        }

        [HttpGet("BookingWaitList")]
        public IActionResult BookingWaitList()
        {
            var values = _bookingService.TGetWaitBookings();
            return Ok(values);
        }

        [HttpGet("BookingCanceledList")]
        public IActionResult BookingCanceledList()
        {
            var values = _bookingService.TGetCancelledBookings();
            return Ok(values);
        }
    }
}
