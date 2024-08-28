using System;
using System.Collections.Generic;

namespace Product.DAL.Entities
{
    public partial class TblBcitem
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal OfferPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public virtual TblBccategory Category { get; set; } = null!;
    }
}
