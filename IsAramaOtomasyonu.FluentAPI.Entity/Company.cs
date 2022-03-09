using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.FluentAPI.Entity
{
    public class Company
    {
        public Company()
        {
            Jobs = new HashSet<Job>();
        }      
        public int CompanyId { get; set; }      
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }       
        public string Password { get; set; }    
        public string Address { get; set; }      
        public byte JobRight { get; set; } = 3;
        public ICollection<Job>  Jobs { get; set; }
    }
}
