using System;
using System.Collections.Generic;

namespace Product.DAL.Entities
{
    public partial class TblDpcategory
    {
        public TblDpcategory()
        {
            TblDpproducts = new HashSet<TblDpproduct>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TblDpproduct> TblDpproducts { get; set; }
    }
}
