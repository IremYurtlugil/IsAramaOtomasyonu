using IsAramaOtomasyonu.FluentAPI.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.FluentAPI.Entity
{
    public class Job
    {
        public Job()
        {
            FringeBenefits = new HashSet<FringeBenefit>();
        }
       
        public int JobId { get; set; }       
        public string Position { get; set; }       
        public string Description { get; set; }
        public byte? Quality { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public JobType JobType { get; set; }
        public decimal? Salary { get; set; }    
        public int CompanyId { get; set; }  

        //Navigation Property
        public Company Company { get; set; }
        public ICollection<FringeBenefit> FringeBenefits { get; set; }

    }
}
