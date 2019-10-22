using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis.Models
{
    public class ClassRoom 
    {
        public ClassRoom()
        {
            ClassRoomDamages = new List<ClassRoomDamage>();
        }
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Class Room Name")]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        [DisplayName("Class Room Capacity")]
        public int Capacity { get; set; }

        public Guid FireStationId { get; set; }
        public virtual FireStation FireStation { get; set; }

        public virtual ICollection<ClassRoomDamage> ClassRoomDamages { get; set; }

    }
}