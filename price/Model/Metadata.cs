using System;

namespace Model
{
    public class Metadata
    {
        public DateTime DateCreated { get; set; }

        public int CreatedBy { get; set; }


        public bool IsApproved { get; set; }

        public DateTime? DateApproved { get; set; }

        public int? ApprovedBy { get; set; }


        public bool IsDeleted { get; set; }

        public DateTime? DateDeleted { get; set; }

        public int? DeletedBy { get; set; }
    }
}
