﻿
using RentService.Entities;
namespace RentService.Services
{
     class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }

        ITaxservice _TaxService;
        public RentalService(double pricePerHour, double pricePerDay,ITaxservice iTaxservice)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _TaxService = iTaxservice;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;

            if(duration.TotalHours <= 12.0) {
                basicPayment=PricePerHour*Math.Ceiling(duration.TotalHours);

            }
            else
            {
                basicPayment=PricePerDay*Math.Ceiling(duration.TotalDays);
            }

            double tax = _TaxService.Tax(basicPayment);

            carRental.Invoice= new Invoice(basicPayment, tax);

        }
    }
}
