using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flights.Helpers
{
    public static class wait
    {
        public static T waitForObject<T> (Func<T> method, int cycles, int timeout=500 ) where T:class
        {
            T element = null;
            int count =0;

            while (element==null && count<cycles){

                try{
                    element = method.Invoke();
                }
                catch(Exception ex){ Logger.Log.Error("Element isn't found", ex);}

                count++;
                Thread.Sleep(timeout);
            }

            return element;   
        }

         public static void waitForTrue (Func<bool> method, int cycles = 5, int timeout=500 )
        {
            bool result = false;
            int count =0;

            while (!result && count<cycles){

                try
                {
                    result = method.Invoke();
                }
                catch(Exception ex){ Logger.Log.Error("Element isn't found", ex);}

                count++;
                Thread.Sleep(timeout);
            }
        }
    }
}
