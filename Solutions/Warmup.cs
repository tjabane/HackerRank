using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public class Warmup
    {
        public string MiniMaxSum(int[] arr)
        {
            var ordered = arr.Select(Convert.ToInt64).OrderByDescending(n => n);
            var max = ordered.Take(4).Sum();
            var min = ordered.Skip(1).Sum();
            return $"{min} {max}";
        }


        public int CountingValleys(string path)
        {
            var numPath = path.Select(c => c == 'D' ? -1 : 1).ToList();
            var trajectory = new List<int>();
            for (var i = 0; i < numPath.Count; i++)
            {
                if (i == 0)
                    trajectory.Add(numPath[i]);
                else
                    trajectory.Add(numPath[i] + trajectory.Last());
            }

            var valleys = trajectory.Select((point, index) => new { value = point, i = index })
                                        .Count(point => point.value == 0 && trajectory[point.i - 1] < 0);
            return valleys;
        }


        static int JumpingOnClouds(int[] path, int step, int currentLoc)
        {
            if (currentLoc > path.Length - 1)
                return int.MaxValue;
            if (path[currentLoc] == 0 && currentLoc == path.Length - 1)
                return step;
            if (path[currentLoc] == 1)
                return int.MaxValue;

            var next = step + 1;
            return Math.Min(JumpingOnClouds(path, next, currentLoc + 1),
                JumpingOnClouds(path, next, currentLoc + 2));
        }


        public static long RepeatedString(string sub, long length)
        {
            var multiplier = (length / sub.Length);
            var currentCount = sub.Count(c => c == 'a') * multiplier;
            var currentLen = multiplier * sub.Length;

            for (var i = 0; i < length - currentLen; i++)
            {
                if (sub[i] == 'a')
                    currentCount++;
            }
            return currentCount;
        }



    }
}
