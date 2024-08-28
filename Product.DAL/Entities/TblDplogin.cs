using System;
using System.Collections.Generic;

namespace Product.DAL.Entities
{
    public partial class TblDplogin
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
