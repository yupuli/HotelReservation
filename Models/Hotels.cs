namespace HotelReservation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hotels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotels()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(1)]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        public int OwnerId { get; set; }

        public virtual Owners Owners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
