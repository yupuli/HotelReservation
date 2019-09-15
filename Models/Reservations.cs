namespace HotelReservation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservations
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int CustomerId { get; set; }

        public int HotelId { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Hotels Hotels { get; set; }

        public virtual Owners Owners { get; set; }
    }
}
