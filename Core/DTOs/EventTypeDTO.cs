using BienComun.Core.Entities;
using BienComun.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Core.DTOs
{
    public class EventTypeDTO
    {
        [Required]
        public EventType EventType { get; set; }

        [MaxLength(50)]
        public string? CustomEventType { get; set; }
    }
}
