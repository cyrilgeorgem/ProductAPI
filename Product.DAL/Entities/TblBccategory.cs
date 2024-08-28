using System;
using System.Collections.Generic;

namespace Product.DAL.Entities
{
    public partial class TblBccategory
    {
        public TblBccategory()
        {
            TblBcitems = new HashSet<TblBcitem>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<TblBcitem> TblBcitems { get; set; }
    }
}
