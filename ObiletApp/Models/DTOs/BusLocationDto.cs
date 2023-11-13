using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ObiletApp.Models.DTOs
{
    public class BusLocationDto
    {
        public DateTime DeparturaDate { get; set; }
        public int OrigionId { get; set; }
        public int DestinationId { get; set; }
    }
    
}
