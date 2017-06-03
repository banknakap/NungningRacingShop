using Nungning.BLL.Controller;
using NungningRacingShop.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NungningRacingShop.Controller
{
    public class CartController
    {
        public static bool addCart(CartInfo cart)
        {
      

            if (SessionApp.cart_session.Find((x => (x.product_id == cart.product_id))) != null)
            {
                foreach (var c in SessionApp.cart_session)
                {
                    if (c.product_id == cart.product_id)
                    {
                        c.amount += cart.amount;

                        var pro = ProductController.GetProduct(c.product_id, null).FirstOrDefault();
                        if (pro.amount < c.amount)
                        {
                            c.amount -= cart.amount;
                            return false;
                        }
                    }

                }
                return true;
            }
            else
            {
                var pro = ProductController.GetProduct(cart.product_id, null).FirstOrDefault();
                if (pro.amount >= cart.amount)
                {
                    SessionApp.cart_session.Add(cart);
                    return true;
                }
                else
                {
                    return false;
                }

            }

            }

            public static List<CartInfo> delCartItem(CartInfo cart)
            {
                if (SessionApp.cart_session.Count > 0)
                {
                    SessionApp.cart_session.Remove(cart);
                }
                return SessionApp.cart_session;
            }

            public static CartInfo getCartInfo(string product_id)
            {
                return SessionApp.cart_session.Where(d => d.product_id == product_id).FirstOrDefault();
            }
        }
    }