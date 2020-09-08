using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PermisosAPI.Models
{
    public class Permit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeLastname { get; set; }

        [Required]
        public int PermitTypeId { get; set; }

        [Required]
        public DateTime PermitDate { get; set; }

        public PermitType PermitType { get; set; }

        public class Map{
            
            public Map(EntityTypeBuilder<Permit> mapPermit)
            {
                mapPermit.HasOne(x => x.PermitType);
            }
        }
    }
}
