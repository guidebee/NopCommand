﻿using System;
using NopCommand.Domain.Directory;

namespace NopCommand.Domain.Common
{
    public partial class Address : BaseEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the company
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state/province identifier
        /// </summary>
        public int? StateProvinceId { get; set; }
        
        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the zip/postal code
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the fax number
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the custom attributes (see "AddressAttribute" entity for more info)
        /// </summary>
        public string CustomAttributes { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
        
        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public  Country Country { get; set; }

        /// <summary>
        /// Gets or sets the state/province
        /// </summary>
        public  StateProvince StateProvince { get; set; }


        public object Clone()
        {
            var addr = new Address
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Company = Company,
                Country = Country,
                CountryId = CountryId,
                StateProvince = StateProvince,
                StateProvinceId = StateProvinceId,
                City = City,
                Address1 = Address1,
                Address2 = Address2,
                ZipPostalCode = ZipPostalCode,
                PhoneNumber = PhoneNumber,
                FaxNumber = FaxNumber,
                CustomAttributes = CustomAttributes,
                CreatedOnUtc = CreatedOnUtc,
            };
            return addr;
        }
    }
}
