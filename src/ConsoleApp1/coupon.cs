using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Coupon:IComparable
    {
        public int amount { get; set; }
        public int percentage { get; set; }
        public bool applicableAll { get; set; }
        public float minPrice { get; set; }
        public float maxPrice { get; set; }
        public int applications { get; set; }
        public Coupon()
        {
            amount = 0;
            percentage = 0;
            applicableAll = false;
            minPrice = 0;
            maxPrice = 0;
            applications = 0;
        }
        public Coupon(int _amount, int _percentage, bool _applicableAll, int _applications = 1, float _minPrice = 0, float _maxPrice = 0 )
        {
            amount = 1;
            if (_applications != 0)
            {
                applications = _applications*_amount;
            }
            else
            {
                throw (new Exception("wrong amount"));
            }
            if (_minPrice < 0)
            {
                _minPrice = 0;
            }
            if (_maxPrice < 0)
            {
                _maxPrice = 0;
            }
            if (_maxPrice == 0 && _applicableAll == false)
            {
                throw new Exception("Invalid coupon");
            }
            if (_maxPrice < _minPrice)
            {
                var temp = _minPrice;
                _minPrice = _maxPrice;
                _maxPrice = temp;
            }
            percentage = _percentage;
            applicableAll = _applicableAll;
            if (!applicableAll)
            {
                minPrice = _minPrice;
                maxPrice = _maxPrice;
            }
            
        }
        public static bool operator <(Coupon lhs, Coupon rhs)
        {
            bool status = false;
            if (lhs.percentage < rhs.percentage)
            {
                status = true;
            }
            return status;
        }
        public static bool operator >(Coupon lhs, Coupon rhs)
        {
            bool status = false;
            if (lhs.percentage > rhs.percentage)
            {
                status = true;
            }
            return status;
        }

        public int CompareTo(object _obj)
        {
            if (_obj != null)
            {
                Coupon obj = _obj as Coupon;
                return obj.percentage.CompareTo(percentage);
            }
            return 0;
        }
    }
}
