// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="EncryptionCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Services.Security;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class EncryptionCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class EncryptionCommands
    {
        /// <summary>
        /// Creates the salt key.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string CreateSaltKey(int size)
        {
            var encryptionService = EngineContext.Current.Resolve<IEncryptionService>();
            var primitiveCore = encryptionService.CreateSaltKey(size);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Creates the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="saltkey">The saltkey.</param>
        /// <param name="passwordFormat">The password format.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            var encryptionService = EngineContext.Current.Resolve<IEncryptionService>();
            var primitiveCore = encryptionService.CreatePasswordHash(password, saltkey, passwordFormat);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Encrypts the text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="encryptionPrivateKey">The encryption private key.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string EncryptText(string plainText, string encryptionPrivateKey = "")
        {
            var encryptionService = EngineContext.Current.Resolve<IEncryptionService>();
            var primitiveCore = encryptionService.EncryptText(plainText, encryptionPrivateKey);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Decrypts the text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="encryptionPrivateKey">The encryption private key.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string DecryptText(string cipherText, string encryptionPrivateKey = "")
        {
            var encryptionService = EngineContext.Current.Resolve<IEncryptionService>();
            var primitiveCore = encryptionService.DecryptText(cipherText, encryptionPrivateKey);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}
