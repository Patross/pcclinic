using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcclinic.classes
{
    class Booking
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public string JobType { get; set; }

        private Booking()
        {

        }

        public Booking(string clientName, DateTime startDate, DateTime deadline, string jobType) : this()
        {
            ClientName = clientName;
            StartDate = startDate;
            Deadline = deadline;
            JobType = JobType;

            
        }
    }
}
