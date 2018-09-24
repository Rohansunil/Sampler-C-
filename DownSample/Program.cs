using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampler
{
    class Bucket
    {
        public static Dictionary<string, int> bucket = new Dictionary<string, int>();
        static int threshold;
        public static Dictionary<string, int> globalPeakTrough = new Dictionary<string, int>();
        public static int modeOfSample;
        public static void CalcModeOfSample()
        {
            int noOfModeElement = 0, positionOfElement = -1;
            List<int> intList = new List<int>();
            IEnumerable<IGrouping<int, int>> grp = bucket.Values.GroupBy(x => x);
            foreach (IGrouping<int, int> item in grp)
            {
                intList.Add(item.Count());
            }

            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i] == intList.Max())
                {
                    noOfModeElement++;
                    positionOfElement = i;
                }
            }
            if (noOfModeElement == 1)
            {
                modeOfSample = Bucket.bucket[Bucket.bucket.Keys.ElementAt(positionOfElement)];
            }
            else
            {
                modeOfSample = -1;
            }

        }
    }
    class DownSample
    {
        public static KeyValuePair<string, int> downsampling()
        {
            if (Bucket.bucket.Contains(new KeyValuePair<string, int>(Bucket.globalPeakTrough.Keys.ElementAt(0), Bucket.globalPeakTrough[Bucket.globalPeakTrough.Keys.ElementAt(0)])))
            {
                return new KeyValuePair<string, int>(Bucket.globalPeakTrough.Keys.ElementAt(0), Bucket.globalPeakTrough[Bucket.globalPeakTrough.Keys.ElementAt(0)]);
            }
            else if (Bucket.modeOfSample != -1)
            {
                return SingleFrequentYValue();
            }
            else
            {
                if (Bucket.bucket.Count % 2 == 0)
                {
                    return new KeyValuePair<string, int>(Bucket.bucket.Keys.ElementAt((Bucket.bucket.Count / 2) - 1), Bucket.bucket[Bucket.bucket.Keys.ElementAt((Bucket.bucket.Count / 2) - 1)]);
                }
                else
                {
                    return new KeyValuePair<string, int>(Bucket.bucket.Keys.ElementAt((Bucket.bucket.Count / 2)), Bucket.bucket[Bucket.bucket.Keys.ElementAt((Bucket.bucket.Count / 2))]);
                }
            }


        }

        static KeyValuePair<string, int> SingleFrequentYValue()
        {
            if (Bucket.bucket.Count == 1)
            {
                return new KeyValuePair<string, int>(Bucket.bucket.Keys.ElementAt(0), Bucket.bucket[Bucket.bucket.Keys.ElementAt(0)]);
            }
            else
            {
                for (int i = 0; i < Bucket.bucket.Count(); i++)
                {
                    if (Bucket.bucket[Bucket.bucket.Keys.ElementAt(i)] == Bucket.modeOfSample)
                    {
                        return new KeyValuePair<string, int>(Bucket.bucket.Keys.ElementAt(i), Bucket.bucket[Bucket.bucket.Keys.ElementAt(i)]);
                    }
                }

            }
            return new KeyValuePair<string, int>(null, -1);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Bucket.bucket.Add("9:00", 3);
            Bucket.bucket.Add("9:01", 3);
            Bucket.bucket.Add("9:02", 2);
            Bucket.bucket.Add("9:03", 6);
            Bucket.bucket.Add("9:04", 6);
            Bucket.bucket.Add("9:05", 1);
            Bucket.bucket.Add("10:01", 10);
            Bucket.globalPeakTrough.Add("10:00", 10);
            Bucket.CalcModeOfSample();
            Console.WriteLine(DownSample.downsampling());
            Console.ReadKey();

        }
    }
}