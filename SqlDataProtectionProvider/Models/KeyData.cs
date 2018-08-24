using System;
using System.Collections.Generic;

namespace SqlDataProtectionProvider.Models
{
    public partial class KeyData
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }
        public string XmlData { get; set; }
    }
}
