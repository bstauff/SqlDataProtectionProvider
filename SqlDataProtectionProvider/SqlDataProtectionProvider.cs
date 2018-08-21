using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace SqlDataProtectionProvider
{
    public class SqlDataProtectionProvider : IXmlRepository
    {
        private readonly string _connectionString;

        public SqlDataProtectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            throw new NotImplementedException();
        }
    }
}
