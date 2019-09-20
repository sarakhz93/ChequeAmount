using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChequeAmount.Models
{
    public interface INumberToWordConvertor
    {
        string NumberToWords(string Number);
    }
}
