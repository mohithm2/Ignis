using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class Rank
    {
        public Rank()
        {
            Employees = new List<Employee>();
            Counts = new List<Count>();
            //CountsSU = new HashSet<CountSU>();
            Vacancies = new List<Vacancy>();
            //VacanciesSU = new HashSet<VacancySU>();
        }
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Designation")]
        public string RankName { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Count> Counts { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        //public virtual ICollection<VacancySU> VacanciesSU { get; set; }
        //public virtual ICollection<CountSU> CountsSU { get; set; }
    }
}