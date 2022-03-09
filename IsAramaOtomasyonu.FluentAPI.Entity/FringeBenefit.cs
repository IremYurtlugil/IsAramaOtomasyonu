using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.FluentAPI.Entity
{
    public class FringeBenefit
    {
        public FringeBenefit()
        {
            Jobs = new HashSet<Job>();
        }
        public int FringeBenefitId { get; set; }
        public string Description { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
