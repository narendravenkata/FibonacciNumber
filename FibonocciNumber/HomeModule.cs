using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace FibonocciNumber
{
    public class HomeModule:NancyModule
    {
        public HomeModule()
        {
            Get("/{number}", x => {
                return GetFibonacciNumber(x.number);
            });
        }

        public Response GetFibonacciNumber(int number)
        {
            var ans = Fib(number);
            return Response.AsJson(ans);
        }

        public int Fib(int N)
        {
            if (N == 0)
            {
                return 0;
            }
            int[] seq = new int[N + 1];
            seq[0] = 0;
            seq[1] = 1;
            for (int i = 2; i <= N; i++)
            {
                seq[i] = seq[i - 1] + seq[i - 2];
            }

            return seq[N];
        }
    }
}
