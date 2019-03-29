using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcclinic.classes
{
     class Finance
    {
        public int Id { get; set; }
        public decimal Money { get; set; }

        private Finance()
        {

        }
        public Finance(decimal money)
        {
            Money = money;
        }
    }
}
