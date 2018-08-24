using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using SqlDataProtectionProvider.Models;

namespace SqlDataProtectionProvider
{
    public class SqlDataProtectionProvider : IXmlRepository
    {
        private readonly DbContextOptions<DataProtectionContext> _options;

        public SqlDataProtectionProvider(DbContextOptions<DataProtectionContext> options)
        {
            _options = options;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            using (var context = new DataProtectionContext(_options))
            {
                var elements = new ReadOnlyCollection<XElement>(context.KeyData.Select(x => XElement.Parse(x.XmlData)).ToList());

                return elements;
            } 
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            using (var context = new DataProtectionContext(_options))
            {
                var existingEntity = context.KeyData.SingleOrDefault(x => x.FriendlyName.Equals(friendlyName));

                if (existingEntity == null)
                {
                    //Add the new one
                    context.KeyData.Add(new KeyData
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

                context.SaveChanges();
            }
        }
    }
}
