﻿using System.Collections.Generic;
using System.Linq;

namespace ProductCart.App
{
    public class Customer
    {
        private CartItem _cartItem;
        private Cart _cart = new Cart();
        private Discount _discount = new Discount();

        public void AddProductToCart(Product product, int quantity)
        {
            if (quantity < 0)
                throw new NegativeQuantityException();
            else
            {
                bool isAlreadyInCart = _cart.CheckIfAlreadyInCart(product);
                if (isAlreadyInCart)
                {
                    ReadCartProductsList().Where(x => x.Product == product).ToList().ForEach(s => this._cartItem = s);
                    this._cartItem.Quantity += quantity;
                    this._cartItem.CumulativeProductCost = this._cartItem.Product.GetProductPrice() * this._cartItem.Quantity;
                }
                else
                {
                    _cartItem = new CartItem(product, quantity);
                    _cart.AddNewProductToList(_cartItem);
                }
            }
        }

        public List<CartItem> ReadCartProductsList()
        {
            return _cart.GetCartProductsList();
        }

        public double GetTotalPrice()
        {
            return _cart.GetTotalCartPrice();
        }

        public void ApplyDiscount()
        {
            string discountType = "NONE";
            _discount.ApplyDiscount(discountType, _cart);
        }

        public void ApplyDiscount(string discountType)
        {
            _discount.ApplyDiscount(discountType, _cart);
        }

        public double GetDiscountPrice()
        {
            return _discount.GetDiscountAmount();
        }

        public double GetFinalPriceAfterDiscount()
        {
            return (GetTotalPrice() - GetDiscountPrice());
        }
    }
}