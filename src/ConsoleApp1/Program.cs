using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public void Main(string[] args)
        {
            int cAmount=0;
            int pAmount=0;
            List<Coupon> couponList = new List<Coupon>();
            List<Product> productList = new List<Product>();
            bool correct = false;
///////////////////////////////////////////////////////////////////////////////////
            do
            {
                Console.WriteLine("Enter the amount of products you wish to purchase:");
                try
                {
                    pAmount = Convert.ToInt32(Console.ReadLine());
                    correct = true;
                }
                catch
                {
                    Console.WriteLine("Wrong amount. Try again");
                }
            }
            while (correct != true);
///////////////////////////////////////////////////////////////////////////////////
            correct = false;
            do
            {
                Console.WriteLine("Enter the amount of coupons you wish to use:");

                try
                {
                    cAmount = Convert.ToInt32(Console.ReadLine());
                    correct = true;
                }
                catch
                {
                    Console.WriteLine("Wrong amount. Try again");
                }
            }
            while (correct != true);
///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter the products \n(name, price, amount)");
            for (int i=0;i<pAmount;++i)
            {
                correct = false;
                do
                {
                    string temp = Console.ReadLine();
                    var arr = temp.Split(' ');
                    try
                    {
                        productList.Add(new Product(arr[0], Convert.ToDouble(arr[1]), Convert.ToInt32(arr[2])));
                        correct = true;
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input, try again");
                    }
                }
                while (correct != true);
            }
///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter the coupons \n(amount, percentage, if it's applicable to all prices, am. of applications >= 1, [minprice], [maxprice])");
            for (int i = 0; i < cAmount; ++i)
            {
                do {
                    string temp = Console.ReadLine();
                    var arr = temp.Split(' ');
                    try
                    {
                        couponList.Add(new Coupon(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToBoolean(Convert.ToInt32(arr[2])), Convert.ToInt32(arr[3]), Convert.ToInt32(arr[4]), Convert.ToInt32(arr[5])));
                        correct = true;
                    }
                    catch
                    {
                        try
                        {
                            couponList.Add(new Coupon(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToBoolean(Convert.ToInt32(arr[2])), Convert.ToInt32(arr[3]), Convert.ToInt32(arr[4])));
                            correct = true;
                        }
                        catch
                        {
                            try
                            {
                                couponList.Add(new Coupon(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToBoolean(Convert.ToInt32(arr[2])), Convert.ToInt32(arr[3])));
                                correct = true;
                            }
                            catch
                            {
                                try
                                {
                                    couponList.Add(new Coupon(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToBoolean(Convert.ToInt32(arr[2]))));
                                    correct = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Wrong input, try again");
                                }
                            }
                        }
                    }
                } while (correct != true);
            }
///////////////////////////////////////////////////////////////////////////////////
            couponList.Sort();
            productList.Sort();
            //List<Coupon> couponList2 = new List<Coupon>(couponList);
            //couponList2.Reverse();
            //List<Product> productList2 = new List<Product>(productList);
///////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\n");
            Console.WriteLine("Best for customer");

            double sum = 0;
            foreach (var product in productList)
            {
                sum += product.price;
            }
            Console.WriteLine("Total price " + sum);

            foreach (var product in productList)
            {
                if (product.amount == 0)
                {
                    continue;
                }
                foreach (var coupon in couponList)
                {
                    if (((coupon.applicableAll) || ((coupon.maxPrice < product.price) && coupon.minPrice > product.price)) && (coupon.applications > 0) && (product.amount != 0))
                    {
                        Console.WriteLine("Coupon with value " + coupon.percentage + " applied to product " + product.name + " with price " + product.price);
                        double savings;
                        if (coupon.applications < product.amount)
                        {
                            product.amount -= coupon.applications;
                            savings = coupon.applications * product.price * coupon.percentage / 100;
                            coupon.applications = 0;
                        }
                        else if (coupon.applications > product.amount)
                        {
                            coupon.applications -= product.amount;
                            savings = product.amount * product.price * coupon.percentage / 100;
                            product.amount = 0;
                        }
                        else
                        {
                            savings = product.amount * product.price * coupon.percentage / 100;
                            coupon.applications = 0;
                            product.amount = 0;
                        }
                        sum -= savings;
                        continue;
                    }
                }
            }
            Console.WriteLine("Sum, after application of coupons: " + sum);
///////////////////////////////////////////////////////////////////////////////////
            //Console.WriteLine("\n\n");
            //Console.WriteLine("Best for seller");

            //double sum2 = 0;
            //foreach (var product in productList2)
            //{
            //    sum2 += product.price;
            //}
            //Console.WriteLine("Total price " + sum);

            //foreach (var product in productList2)
            //{
            //    if (product.amount == 0)
            //    {
            //        continue;
            //    }
            //    foreach (var coupon in couponList2)
            //    {
            //        if (((coupon.applicableAll) || ((coupon.maxPrice < product.price) && coupon.minPrice > product.price)) && (coupon.applications > 0))
            //        {
            //            Console.WriteLine("Coupon with value " + coupon.percentage + " applied to product " + product.name + " with price " + product.price);
            //            double savings;
            //            if (coupon.applications < product.amount)
            //            {
            //                product.amount -= coupon.applications;
            //                savings = coupon.applications * product.price * coupon.percentage / 100;
            //                coupon.applications = 0;
            //            }
            //            else if (coupon.applications > product.amount)
            //            {
            //                coupon.applications -= product.amount;
            //                savings = product.amount * product.price * coupon.percentage / 100;
            //                product.amount = 0;
            //            }
            //            else
            //            {
            //                savings = product.amount * product.price * coupon.percentage / 100;
            //                coupon.applications = 0;
            //                product.amount = 0;
            //            }
            //            sum2 -= savings;
            //        }
            //    }
            //}
            //Console.WriteLine("Sum, after application of coupons: " + sum2);
        }
    }
}
