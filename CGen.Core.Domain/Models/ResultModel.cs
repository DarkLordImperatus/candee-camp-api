﻿namespace CGen.Core.Domain.Models
{
    public class ResultModel<T>
    {
        public ResultModel(T result)
        {
            Result = result;
        }
        
        public T Result { get; set; }
    }
}