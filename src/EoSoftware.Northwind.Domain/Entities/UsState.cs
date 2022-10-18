using System;
using System.Collections.Generic;

namespace EoSoftware.Northwind.Domain.Entities
{
    public class UsState
    {
        public short StateId { get; set; }
        public string? StateName { get; set; }
        public string? StateAbbr { get; set; }
        public string? StateRegion { get; set; }
    }
}
