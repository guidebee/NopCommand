// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="PictureCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Domain.Media;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Media;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class PictureCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class PictureCommands
    {
        /// <summary>
        /// Gets the name of the picture se.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPictureSeName(string name)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var primitiveCore = pictureService.GetPictureSeName(name);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the default picture URL.
        /// </summary>
        /// <param name="targetSize">Size of the target.</param>
        /// <param name="defaultPictureType">Default type of the picture.</param>
        /// <param name="storeLocation">The store location.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDefaultPictureUrl(int targetSize = 0, PictureType defaultPictureType = PictureType.Entity, string storeLocation = null)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var primitiveCore = pictureService.GetDefaultPictureUrl(targetSize, defaultPictureType, storeLocation);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the picture URL.
        /// </summary>
        /// <param name="pictureId">The picture identifier.</param>
        /// <param name="targetSize">Size of the target.</param>
        /// <param name="showDefaultPicture">if set to <c>true</c> [show default picture].</param>
        /// <param name="storeLocation">The store location.</param>
        /// <param name="defaultPictureType">Default type of the picture.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPictureUrl(int pictureId, int targetSize = 0, bool showDefaultPicture = true, string storeLocation = null, PictureType defaultPictureType = PictureType.Entity)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var primitiveCore = pictureService.GetPictureUrl(pictureId, targetSize, showDefaultPicture, storeLocation, defaultPictureType);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the picture by identifier.
        /// </summary>
        /// <param name="pictureId">The picture identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPictureById(int pictureId)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var pictureCore = pictureService.GetPictureById(pictureId);
            var picture = AutoMapperConfiguration.Mapper.Map<Domain.Media.Picture>(pictureCore);
            return JsonConvert.SerializeObject(picture, Formatting.Indented);
        }

        /// <summary>
        /// Gets the pictures.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPictures(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var pictureCore = pictureService.GetPictures(pageIndex, pageSize);
            var picture = pictureCore.MapSourcePageList<Picture, Domain.Media.Picture>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(picture, Formatting.Indented, new PageListConverter<Domain.Media.Picture>());
        }

        /// <summary>
        /// Gets the pictures by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="recordsToReturn">The records to return.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPicturesByProductId(int productId, int recordsToReturn = 0)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var pictureCore = pictureService.GetPicturesByProductId(productId, recordsToReturn);
            var picture = pictureCore.MapSource<Picture, Domain.Media.Picture>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(picture, Formatting.Indented);
        }

        /// <summary>
        /// Sets the seo filename.
        /// </summary>
        /// <param name="pictureId">The picture identifier.</param>
        /// <param name="seoFilename">The seo filename.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SetSeoFilename(int pictureId, string seoFilename)
        {
            var pictureService = EngineContext.Current.Resolve<IPictureService>();
            var pictureCore = pictureService.SetSeoFilename(pictureId, seoFilename);
            var picture = AutoMapperConfiguration.Mapper.Map<Domain.Media.Picture>(pictureCore);
            return JsonConvert.SerializeObject(picture, Formatting.Indented);
        }

    }
}
