﻿using System;

namespace ProductCart.App
{
    public class DiscountFactory
    {
        public IDiscount GetDiscount(string discountType)
        {
            switch(discountType.ToUpper())
            {
                case "FIXED":
                    return new FixedDiscount();
                case "CATEGORYWISE":
                    return new CategoryDiscount();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
