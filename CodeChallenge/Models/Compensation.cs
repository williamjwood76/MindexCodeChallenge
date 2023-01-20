using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        [Key]
        public int compensationId { get; set; }
        public Employee employee { get; set; }

        public double salary { get; set; }

        public DateTime effectiveDate { get; set; }
    }
}