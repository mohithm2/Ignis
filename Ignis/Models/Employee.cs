using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Employee
    {
        public Employee()
        {
            WorksFors = new HashSet<WorksFor>();
        }
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("KGID")]
        [StringLength(25, ErrorMessage = "Invalid KGID")]
        public string Kgidno { get; set; }

        [DisplayName("Hyderabad Karnataka Region")]
        public bool HK { get; set; }

        [DisplayName("Spouse Cadre Applied")]
        public bool SpouseCadre { get; set; }

        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Date of Joining")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("Phone")]
        [StringLength(10, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Seniority")]
        public int Seniority { get; set; }

        public Guid TalukId { get; set; }
        public virtual Taluk Taluk { get; set; }
        public Guid RankId { get; set; }
        public virtual Rank Rank { get; set; }
        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }
        public virtual ICollection<WorksFor> WorksFors { get; set; }

    }
}