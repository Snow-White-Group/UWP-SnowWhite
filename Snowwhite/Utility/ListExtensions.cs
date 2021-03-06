﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowwhite.Utility
{
    public static class ListExtensions
    {
        private static readonly Random Rng = new Random();

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
