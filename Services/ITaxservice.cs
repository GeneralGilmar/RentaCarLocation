using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentService.Services
{
    interface ITaxservice
    {
        public double Tax(double amount);
    }
}
