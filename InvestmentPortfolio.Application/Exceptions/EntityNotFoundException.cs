﻿using System;

namespace InvestmentsPortfolioAPI.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base() { }

        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string message, Exception ex) : base(message, ex) { }
    }
}
