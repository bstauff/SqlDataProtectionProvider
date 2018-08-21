using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;
using SqlDataProtectionProvider.Models;

namespace SqlDataProtectionProvider
{
    public class SqlDataProtectionProvider : IXmlRepository
    {
        private readonly DataProtectionContext _context;

        public SqlDataProtectionProvider(DataProtectionContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            var elements = new ReadOnlyCollection<XElement>(_context.KeyDataEntries.Select(x => XElement.Parse(x.XmlData)).ToList());

            return elements;
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            var existingEntity = _context.KeyDataEntries.SingleOrDefault(x => x.FriendlyName.Equals(friendlyName));

            if (existingEntity == null)
            {
                //Add the new one
                _context.KeyDataEntries.Add(new KeyDataEntry
                {
                    FriendlyName = friendlyName,
                    XmlData = element.ToString()
                });
            }
            else
            {
                //Update the existing one
                existingEntity.XmlData = element.ToString();
            }

            _context.SaveChanges();
        }
    }
}
