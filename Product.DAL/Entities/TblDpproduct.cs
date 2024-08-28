using System;
using System.Collections.Generic;

namespace Product.DAL.Entities
{
    public partial class TblDpproduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual TblDpcategory Category { get; set; } = null!;
    }
}
