using System;
using System.Collections;

namespace Calculate
{
    class Calculate
    {
        double[] c;
        int dem = 0;
        String s = "";
        Double Result = 0;
        public Calculate(String st)
        {
            s = st;
        }
        private static bool IsEmpty(Stack c)
        {
            if (c.Count == 0)
                return true;
            else
                return false;
        }
        private int prio(char a)
        {
            if (a == 'v' || a == '^')
                return 4;
            if (a == 'i' || a == 'c' || a == 'w' || a == 'z')
                return 3;
            if (a == '*' || a == '/')
                return 2;
            if (a == '+' || a == '-')
                return 1;
            return 0;
        }
        private void chuyenkyphap()
        {
            Stack a = new Stack();
            c = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    double temp = 0;
                    char ch = s[i];
                    while (ch >= '0' && ch <= '9')
                    {
                        temp = temp * 10 + ch - 48;
                        if (i >= s.Length - 1)
                            break;
                        else
                        {
                            i++;
                            ch = s[i];
                        }
                    }
                    if (s[i] == '.')
                    {
                        i++;
                        ch = s[i];
                        double r = 1;
                        double t = 0;
                        while (ch >= '0' && ch <= '9')
                        {
                            r = r / 10;
                            t = t + ((s[i] - 48) * r);
                            if (i >= s.Length - 1)
                                break;
                            else
                            {
                                i++;
                                ch = s[i];
                            }
                        }
                        temp = temp + t;
                    }
                    c[dem] = temp;
                    dem++;
                }
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' || s[i] == 'v' || s[i] == 'i' || s[i] == 'c' || s[i] == '^' || s[i] == 'w' || s[i] == 'z')
                {
                    if (IsEmpty(a) == true)
                        a.Push((char)(s[i]));
                    else if (prio(s[i]) <= prio((char)(a.Peek())))
                    {
                        c[dem] = (char)(a.Pop());
                        dem++; 
                        a.Push((char)(s[i]));
                    }
                    else 
                        a.Push((char)(s[i]));
                }
                if (s[i] == '(')
                    a.Push((char)(s[i]));
                if (s[i] == ')')
                {
                    char ch;
                    do
                    {
                        ch = Convert.ToChar(a.Pop());
                        if (ch != '(')
                        {
                            c[dem] = ch;
                            dem++;
                        }
                    }
                    while (ch != '(');
                }
            }
            while (IsEmpty(a) != true)
            {
                c[dem] = Convert.ToChar(a.Pop());
                dem++;
            }
        }
        private void ketqua()
        {
            Stack b = new Stack();
            for (int i = 0; i < dem; i++)
            {
                switch ((int)c[i])
                {
                    //Sum operator
                    case '+':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(a + k);
                            break;
                        }
                    //Subtract operator
                    case '-':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(k - a);
                            break;
                        }
                    //Multiply operator
                    case '*':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(a * k);
                            break;
                        }
                    //Division operator
                    case '/':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(k / a);
                            break;
                        }
                    //Sin 
                    case 'i':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Sin((a / 180) * 3.14));
                            break;
                        }
                    //Cos
                    case 'c':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Cos((a / 180) * 3.14));
                            break;
                        }
                    //Tan
                    case 'w':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Tan((a / 180) * 3.14));
                            break;
                        }
                    //Cotan
                    case 'z':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(1 / (Math.Tan((a / 180) * 3.14)));
                            break;
                        }
                    //Square root
                    case 'v':
                        {
                            double a;
                            a = (double)(b.Pop());
                            b.Push(Math.Sqrt(a));
                            break;
                        }
                    //Square
                    case '^':
                        {
                            double a, k;
                            a = (double)(b.Pop());
                            k = (double)(b.Pop());
                            b.Push(Math.Pow(k, a));
                            break;
                        }
                    default:
                        {
                            b.Push((double)c[i]);
                            break;
                        }
                }
            }
            Result = Convert.ToDouble(b.Pop());
        }
        public double returnKq()
        {
            chuyenkyphap();
            ketqua();
            return this.Result;
        }
    }
}
