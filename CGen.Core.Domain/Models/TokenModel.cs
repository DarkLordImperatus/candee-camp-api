﻿namespace CGen.Core.Domain.Models
{
    public class TokenModel
    {
        public TokenModel(string token)
        {
            Token = token;
        }
        
        public string Token { get; protected set; }
    }
}