// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="VendorCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Vendors;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class VendorCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class VendorCommands
    {
        /// <summary>
        /// Gets the vendor by identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetVendorById(int vendorId)
        {
            var vendorService = EngineContext.Current.Resolve<IVendorService>();
            var vendorCore = vendorService.GetVendorById(vendorId);
            var vendor = AutoMapperConfiguration.Mapper.Map<Domain.Vendors.Vendor>(vendorCore);
            return JsonConvert.SerializeObject(vendor, Formatting.Indented);
        }

        /// <summary>
        /// Gets all vendors.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllVendors(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var vendorService = EngineContext.Current.Resolve<IVendorService>();
            var vendorCore = vendorService.GetAllVendors(name, pageIndex, pageSize, showHidden);
            var vendor = vendorCore.MapSourcePageList<Nop.Core.Domain.Vendors.Vendor, Domain.Vendors.Vendor>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(vendor, Formatting.Indented, new PageListConverter<Domain.Vendors.Vendor>());
        }

        /// <summary>
        /// Gets the vendor note by identifier.
        /// </summary>
        /// <param name="vendorNoteId">The vendor note identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetVendorNoteById(int vendorNoteId)
        {
            var vendorService = EngineContext.Current.Resolve<IVendorService>();
            var vendorNoteCore = vendorService.GetVendorNoteById(vendorNoteId);
            var vendorNote = AutoMapperConfiguration.Mapper.Map<Domain.Vendors.VendorNote>(vendorNoteCore);
            return JsonConvert.SerializeObject(vendorNote, Formatting.Indented);
        }

    }
}
