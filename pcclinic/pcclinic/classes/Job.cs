using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcclinic.classes
{
    class Job
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public DateTime Deadline { get; set; }
        public string DeviceType { get; set; }

        private Job()
        {

        }
        public Job(string type, string clientName, DateTime deadline, string deviceType) : this()
        {
            Type = type;
            ClientName = clientName;
            Deadline = deadline;
            DeviceType = deviceType;

        }
    }
}
