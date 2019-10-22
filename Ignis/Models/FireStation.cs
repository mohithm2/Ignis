using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public enum FireStationStatus
    {
        UnderConstruction, Operational, ConstructedNonOperational, UnderRenovationOperational,
        UnderRenovationNonOperational
    }
    public class FireStation
    {
        public FireStation()
        {
            Vehicles = new List<Vehicle>();
            FireExtinguishingEquipments = new List<FireExtinguishingEquipment>();
            TelephoneRooms = new List<TelephoneRoom>();
            ClassRooms = new List<ClassRoom>();
            BreakRooms = new List<BreakRoom>();
            ResidentialQuarters = new List<ResidentialQuarter>();
            Offices = new List<Office>();
            WorksFors = new List<WorksFor>();
            Vacancies = new List<Vacancy>();
            Counts = new List<Count>();
            Employees = new List<Employee>();
            Lands = new List<Land>();
            RequiredLands = new List<RequiredLand>();
            WaterSources = new List<WaterSource>();
            FireStationDamages = new List<FireStationDamage>();
        }

        [Key, ForeignKey("Hobli")]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Fire Station Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Number of Bays")]
        public int NumberOfBays { get; set; }

        [Required]
        [DisplayName("Saction Number")]
        public string SanctionNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public long PhoneNumber { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Land Area")]
        public double LandArea { get; set; }

        [Required]
        [DisplayName("Date of Esatblishment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEstablishment { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        [DisplayName("Cost of Establishment")]
        public double CostOfEstablishment { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Sanctioned Strength")]
        public int SanctionedStrength { get; set; }

        [Required]
        public FireStationStatus Status { get; set; }

        public virtual Hobli Hobli { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<FireExtinguishingEquipment> FireExtinguishingEquipments { get; set; }
        public virtual ICollection<WorksFor> WorksFors { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<Count> Counts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Land> Lands { get; set; }
        public virtual ICollection<RequiredLand> RequiredLands { get; set; }
        public virtual ICollection<TelephoneRoom> TelephoneRooms { get; set; }
        public virtual ICollection<BreakRoom> BreakRooms { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<ResidentialQuarter> ResidentialQuarters { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<WaterSource> WaterSources { get; set; }
        public virtual ICollection<FireStationDamage> FireStationDamages { get; set; }
    }
}

