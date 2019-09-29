﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessCore.DataAccess.Contracts;
using BusinessCore.Enums;
using BusinessCore.Models;
using Microsoft.EntityFrameworkCore;
using BusinessCore.Extensions;

namespace BusinessCore.Services
{
   public class ShoppingCartManager
    {
        private readonly long userId;
        public readonly IDataContextManager ContextManager;

        public ShoppingCart Cart { get; private set; }

        public ShoppingCartManager(long userId, IDataContextManager contextManager)
        {
            this.userId = userId;
            this.ContextManager = contextManager;
        }

        private List<DataAccess.DbModels.PriceMaster> getProductPrices(string[] productIds)
        {
            var list = new List<DataAccess.DbModels.PriceMaster>();
            if (!productIds.Any())
                return list;

            var context = ContextManager.GetContext();
            var priceDbs = context.PriceMasters.Where(o => o.IsActive && productIds.Contains(o.ProductId)).ToList();
            return priceDbs;
        }

        #region "temp"
        //temp
        private string[] prodDescList = new string[]
        {
                "200 gram",
                "1 kg",
                "500 gram",
                "1 pc - 200 g - 1 kg",
                "1 box (12 pieces)",
                "1 dozen (12 qty)"
        };
        static Random rand = new Random((int)DateTime.Now.Ticks);
        #endregion "temp"


        public ShoppingCart CreateCart(int storeId)
        {
            var context = ContextManager.GetContext();
            var status = (int)ShoppingCartStatus.InProgress;

            var storeDb = context.StoreMasters.Where(o => o.IsActive && o.Id == storeId).FirstOrDefault();
            if (storeDb==null)
                throw new BusinessException("Invalid Store-Id.");

            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == userId && o.Status == status).FirstOrDefault();
            if (objDb != null)
                throw new BusinessException("Finish Shopping or Clear Current Cart.");

            objDb = new DataAccess.DbModels.ShoppingCart()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedOn = DateTime.Now,
                Status = (int)ShoppingCartStatus.InProgress,
                StoreId = storeId,
                UserId = userId
            };
            context.ShoppingCarts.Add(objDb);
            context.SaveChanges();

            this.Cart = new ShoppingCart
            {
                Id = objDb.Id,
                StoreId = storeDb.Id,
                StoreName = storeDb.Name,
                StoreImage = storeDb.Image,
                StoreBannerImage = storeDb.BannerImage,
            };

            return this.Cart;
        }

        public ShoppingCart GetCart()
        {
            var status = (int)ShoppingCartStatus.InProgress;

            var context = ContextManager.GetContext();

            var objDb = context.ShoppingCarts.Include(o => o.Items).Include(o=>o.Vouchers).ThenInclude(o=>o.VoucherMaster).Where(o => o.UserId == userId && o.Status == status).FirstOrDefault();
            if (objDb == null)
                return null;

            var storeDb = context.StoreMasters.Where(o => o.IsActive && o.Id == objDb.StoreId).FirstOrDefault();
            if (storeDb == null)
                return null;

            this.Cart = new ShoppingCart
            {
                Id = objDb.Id,
                StoreId = storeDb.Id,
                StoreName = storeDb.Name,
                StoreImage = storeDb.Image,
                StoreBannerImage = storeDb.BannerImage,
            };

            if (objDb.Items != null)
            {
                var pids = objDb.Items.Select(o => o.ProductId).ToArray();

                var products = context.ProductMasters.Where(o => pids.Contains(o.Id)).ToLookup(o => o.Id);
                var prices = getProductPrices(pids);
                foreach (var dbItem in objDb.Items)
                {
                    var p = products.Contains(dbItem.ProductId) ? products[dbItem.ProductId].FirstOrDefault() : null;
                    var price = prices.FirstOrDefault(o => o.ProductId == dbItem.ProductId);

                    var pDescIndex = rand.Next(0, prodDescList.Length);
                    var pDesc = prodDescList[pDescIndex];

                    var item = new CartItemVM
                    {
                        ProductId = dbItem.ProductId,
                        Quantity = dbItem.Quantity,
                        SortOrder = dbItem.SortOrder,
                    };

                    if (p != null)
                    {
                        item.ProductName = p.Name;
                        item.Description = pDesc;
                        item.ShortName = p.ShortName;
                        item.ThumbImage = p.ThumbImage;
                    }

                    if (price != null)
                    {
                        item.MRP = price.MRP;
                        item.Price = price.Price;
                        item.Discount = price.Discount;
                        item.DiscountText = price.DiscountText;
                    }
                    this.Cart.Items.Add(item);
                }

                Cart.AmountBeforeVoucherDiscount = Cart.Items.Sum(o => o.Price);
                foreach (var vouchDb in context.CartVouchers.Include(o=>o.VoucherMaster).Where(o=>o.ShoppingCart.Id==objDb.Id))
                {
                    var vItem = new CartVoucherItem
                    {
                        VoucherId = vouchDb.Id,
                        VoucherCode = vouchDb.VoucherMaster.Code,
                        Description = vouchDb.VoucherMaster.Description,
                        Amount=0
                    };

                    if (vouchDb.VoucherMaster.TryApply(Cart.AmountBeforeVoucherDiscount, out float vAmount))
                        vItem.Amount = vAmount;

                    Cart.Vouchers.Add(vItem);
                }

                Cart.TotalAmount = Cart.Items.Sum(o => o.MRP);
                Cart.TotalItemDiscount = Cart.Items.Sum(o => o.Discount);
                Cart.TotalVoucherDiscount = Cart.Vouchers.Sum(o => o.Amount);
                Cart.NetAmount = Cart.AmountBeforeVoucherDiscount - Cart.TotalVoucherDiscount;
            }

            return this.Cart;
        }

        public ShoppingCart AddItemToCart(string productId)
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == userId && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            var max = 0;
            if (objDb.Items.Any())
                max = objDb.Items.Max(o => o.SortOrder);

            objDb.Items.Add(new DataAccess.DbModels.ShoppingCartItem
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = productId,
                Quantity = 1,
                SortOrder = max + 1
            });

            context.SaveChanges();

            return GetCart();
        }
        public ShoppingCart RemoveItemFromCart(string productId)
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == userId && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            if (objDb.Items == null || objDb.Items.Count == 0)
                throw new BusinessException("Shopping-cart is empty");

            //temp
            var index = rand.Next(0, objDb.Items.Count);
            var itemDb = objDb.Items.ToList()[index];
            //temp

            objDb.Items.Remove(itemDb);
            context.SaveChanges();

            return GetCart();
        }

        public ShoppingCart ApplyVoucher(string voucherCode)
        {
            voucherCode = voucherCode.TrimAll().ToUpper();
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Vouchers).Where(o => o.UserId == userId && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            var voucherDb = context.DiscountVoucherMasters.Where(o => o.Code == voucherCode).FirstOrDefault();

            if(voucherDb == null)
                throw new BusinessException("Code does not exist: "+ voucherCode);

            if (objDb.Vouchers.Any(o=>o.VoucherId== voucherDb.Id))
                throw new BusinessException("Voucher already applied on cart.");

            var cart = GetCart();
            if(!voucherDb.TryApply(cart.AmountBeforeVoucherDiscount,out float vDiscount))
                throw new BusinessException("Voucher not applicable on this cart.");

            objDb.Vouchers.Add(new DataAccess.DbModels.CartVoucher
            {
                Id = Guid.NewGuid().ToString(),
                VoucherId = voucherDb.Id,
                AppliedOn = DateTime.Now,
            });

            context.SaveChanges();

            return GetCart();
        }

        public ShoppingCart RemoveVoucher(string voucherCode)
        {
            voucherCode = voucherCode.TrimAll().ToUpper();
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();

            var vouchDbs = context.CartVouchers.Where(o => o.ShoppingCart.UserId == userId && o.ShoppingCart.Status == status && o.VoucherMaster.Code == voucherCode);
            context.CartVouchers.RemoveRange(vouchDbs);
            context.SaveChanges();

            return GetCart();
        }

        public void DiscardCart()
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == userId && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            objDb.Status = (int)ShoppingCartStatus.Discarded;

            context.SaveChanges();
        }


    }

    
}
