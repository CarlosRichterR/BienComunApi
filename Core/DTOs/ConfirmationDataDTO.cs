using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Core.DTOs
{
    public class ConfirmationDataDTO
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool UseMinContribution { get; set; }
        public bool TermsAccepted { get; set; }
    }
}
