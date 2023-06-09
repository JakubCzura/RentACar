﻿namespace RentACar.WebAPI.Database
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Verifies that the hash of given password matches hashed password
        /// </summary>
        /// <param name="password">Unhashed password</param>
        /// <param name="hash">Hashed password</param>
        /// <returns>True if password matches, otherwise false</returns>
        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        /// <summary>
        /// Hashes password
        /// </summary>
        /// <param name="password">Unhashed password</param>
        /// <returns>Hashed password</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}