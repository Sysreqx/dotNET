using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationIntro
{

    public class Tour
    {
        // Any change allowed here...
        private string _toCountry;
        public string ToCountry
        {
            get
            {
                TourStorage.PopularityStatisticsByCountry[ToCountry]++;
                return _toCountry;
            }

            set
            {
                if (value.Length == 3)
                    _toCountry = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public DateTime[] StartDates { get; private set; }
        public int[] AvailablePlacesPerDate { get; private set; }

        // Property
        public decimal PlaceBaseCost { get; set; }

        public void SetToCountry(string newValue)
        {
            int currentPopularity = TourStorage.PopularityStatisticsByCountry[ToCountry];
            TourStorage.PopularityStatisticsByCountry.Remove(ToCountry);
            TourStorage.PopularityStatisticsByCountry.Add(newValue, currentPopularity);
            ToCountry = newValue;
        }

        public Tour(string toCountry, DateTime[] startDates, int[] avaiablePlacesPerDate, decimal placeBaseCost)
        {
            ToCountry = toCountry;
            StartDates = startDates;
            AvailablePlacesPerDate = avaiablePlacesPerDate;
            PlaceBaseCost = placeBaseCost;

            TourStorage.PopularityStatisticsByCountry.Add(toCountry, 0);
        }

    }

    public class RandDate
    {
        public DateTime d = DateTime.Today;
        public Random rnd = new Random();
        
        public long RandomDate()
        {
            d.AddDays(rnd.Next(1, 100));
            return d.Ticks;
        }

        public int RandomNumberOfTickets()
        {
            return rnd.Next(5, 30);
        }

        public decimal RandomTicketCosts()
        {
            return decimal.Parse(rnd.Next(1000, 10001).ToString());
        }
    }

    public static class TourStorage
    {
        public static Dictionary<string, int> PopularityStatisticsByCountry =
            new Dictionary<string, int>()
            {
                {"USA", 0}, {"Austria", 0}, {"France", 0}, {"Germany", 0}, {"Italy", 0}
            };

        // Random
        public static RandDate d = new RandDate();

        public static Tour[] Tours =
        {
            new Tour(
                // Country
                "USA",
                // Dates
                new [] {
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate())
                },
                // Places
                new [] {d.RandomNumberOfTickets(), d.RandomNumberOfTickets(), d.RandomNumberOfTickets()},
                // Cost
                d.RandomTicketCosts()),

            new Tour(
                // Country
                "Austria",
                // Dates
                new [] {
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate())
                },
                // Places
                new [] {d.RandomNumberOfTickets(), d.RandomNumberOfTickets(), d.RandomNumberOfTickets()},
                // Cost
                d.RandomTicketCosts()),

            new Tour(
                // Country
                "France",
                // Dates
                new [] {
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate())
                },
                // Places
                new [] {d.RandomNumberOfTickets(), d.RandomNumberOfTickets(), d.RandomNumberOfTickets()},
                // Cost
                d.RandomTicketCosts()),

            new Tour(
                // Country
                "Germany",
                // Dates
                new [] {
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate())
                },
                // Places
                new [] {d.RandomNumberOfTickets(), d.RandomNumberOfTickets(), d.RandomNumberOfTickets()},
                // Cost
                d.RandomTicketCosts()),

            new Tour(
                // Country
                "Italy",
                // Dates
                new [] {
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate()),
                    new DateTime(d.RandomDate())
                },
                // Places
                new [] {d.RandomNumberOfTickets(), d.RandomNumberOfTickets(), d.RandomNumberOfTickets()},
                // Cost
                d.RandomTicketCosts()),
        };
    }

    class TicketPurchaseService
    {
        public TicketResponse[] FindByCriteria(TicketRequest request)
        {
            List<TicketResponse> result = new List<TicketResponse>();

            var filteredByCountry = TourStorage.Tours
                .Where(p => p.ToCountry == request.ToCountryCode);

            foreach (var item in filteredByCountry)
            {
                for (int i = 0; i < item.StartDates.Length; i++)
                    if (item.StartDates[i] > request.FromPeriod && item.StartDates[i] < request.ToPeriod)
                        if (item.AvailablePlacesPerDate[i] >= request.TicketCount)
                            result.Add(new TicketResponse(item.StartDates[i], item.PlaceBaseCost));
            }
            return result.ToArray();
        }

        public void BuyTicket(TourStorage TS)
        {

        }
    }
    class TicketRequest
    {
        //    string _toCountryCode;
        //    DateTime _fromPeriod, _toPeriod;
        //    int _ticketCount;

        public string ToCountryCode { get; set; }
        public DateTime FromPeriod { get; set; }
        public DateTime ToPeriod { get; set; }
        public int TicketCount { get; set; }
    }

    class TicketResponse
    {
        public DateTime DepartureTime { get; set; }
        public decimal Cost { get; set; }
        public TicketResponse(DateTime DepartureTime, decimal Cost)
        {
            this.DepartureTime = DepartureTime;
            this.Cost = Cost;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
