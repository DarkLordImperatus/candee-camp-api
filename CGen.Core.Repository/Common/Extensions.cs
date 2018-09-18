﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace CGen.Core.Repository.Common
{
    public static class Extensions
    {
        public static string Encrypt(this string password, string salt)
        {
            var hsa512 = new HMACSHA512(Encoding.UTF8.GetBytes(salt));

            return Convert.ToBase64String(hsa512.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}