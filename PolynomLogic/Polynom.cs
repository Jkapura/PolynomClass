using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomLogic
{
    public class Polynom
    {
        private readonly double[] coeffs;
        public int degree;
        #region Properties
        public double[] Coeffs
        {
            get;
        }
        public int Degree
        {
            get
            {
                return coeffs.Length;
            }
        }
        #endregion
        #region Constructors
        public Polynom()
        {
            this.coeffs = new double[] { };
        }       
         
        public Polynom(params double[] arr)
        {
            if(arr == null)            
                throw new ArgumentNullException("a", "a==null!");
            this.coeffs = new double[arr.Length];
            arr.CopyTo(coeffs, 0);
        }
        #endregion
        #region OverrideMethods
        public override bool Equals(Object obj)
        {
            if (!(obj is Polynom))
                return false;
            return Equals((Polynom)obj);
        }
        
        public override int GetHashCode()
        {
            int hash = coeffs.Length;
            for (int i = 0; i < coeffs.Length; i++)
            {
                hash = hash * (int)Math.Pow(coeffs[i], i);
            }
            return hash;
        }
        public override string ToString()
        {
            string polynomStr = "";
            polynomStr += coeffs[0];
            for (int i = 1; i < coeffs.Length; i++)
            {
                polynomStr += " + " + coeffs[i] + " x^" + (i);
            }
            return polynomStr;
        }
        #endregion
        #region OverloadMethods
        public static Polynom operator +(Polynom p, int num)
        {
            //if (p == null )
            //    throw new ArgumentNullException("arguments == null!");
            //int[] summ = p.coeffs;
            //for(int i = 0; i < summ.Length; i++)
            //{
            //    summ[i] += num;
            //}
            //return new Polynom(summ);
            double[] result = new double[p.coeffs.Length];
            Array.Copy(p.coeffs, result, p.coeffs.Length);
            for (int i = 0; i < result.Length; ++i)
                result[i] += num;
            return new Polynom(result);
        }
        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentNullException("One or both arguments == null!");
            double[] temp = new double[Math.Max(p1.Degree, p2.Degree)];
            if (p1.Degree > p2.Degree)
            {
                Array.Copy(p1.coeffs, temp, temp.Length);
                for (int i = 0; i < p2.Degree; i++)
                    temp[i] += p2.coeffs[i];
            }
            else
            {
                Array.Copy(p2.coeffs, temp, temp.Length);
                for (int i = 0; i < p1.Degree; i++)
                    temp[i] += p1.coeffs[i];
            }
            return new Polynom(temp);
        }
        public static Polynom operator -(Polynom p, int num)
        {
            return p + (-num);
        }
        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            return p1 + (p2 * -1);
        }
        public static Polynom operator *(Polynom p, int num)
        {
            if (p == null)
                throw new ArgumentNullException("arguments == null!");
            if (num == 0)
                return new Polynom(0);
            double[] result = new double[p.coeffs.Length];
            Array.Copy(p.coeffs, result, p.coeffs.Length);
            for (int i = 0; i < result.Length; i++)
                result[i] *= num;
            return new Polynom(result);

        }
        public static Polynom operator /(Polynom p, int num)
        {
            if (p == null)
                throw new ArgumentNullException("arguments == null!");
            if (num == 0)
                return new Polynom(0);
            double[] result = new double[p.coeffs.Length];
            Array.Copy(p.coeffs, result, p.coeffs.Length);
            for (int i = 0; i < result.Length; i++)
                result[i] /= num;
            return new Polynom(result);

        }
        public static bool operator ==(Polynom p1, Polynom p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Polynom p1, Polynom p2)
        {
            return p1.Equals(p2);
        }
        #endregion
        public bool Equals(Polynom other)
        {
            if (other == null)
                return false;

            if (this.coeffs.Length != other.coeffs.Length)
                return false;

            for (int i = 0; i < this.coeffs.Length; i++)
            {
                if (this.coeffs[i] != other.coeffs[i])
                    return false;
            }
            return true;
        }
    }
}
