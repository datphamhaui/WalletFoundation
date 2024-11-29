﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Reown.Core
{
    public static class Utils
    {
        private const string SessionIdPattern = @"^[-a-z0-9]{3,8}:[-_a-zA-Z0-9]{1,32}$";
        private static readonly Regex SessionIdRegex = new(SessionIdPattern, RegexOptions.None, TimeSpan.FromSeconds(1));

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return false;

            try
            {
                _ = new Uri(url);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsValidChainId(string chainId)
        {
            return SessionIdRegex.IsMatch(chainId);
        }

        public static bool IsValidAccountId(string account)
        {
            if (string.IsNullOrWhiteSpace(account) || !account.Contains(':'))
            {
                return false;
            }

            var split = account.Split(":");
            if (split.Length != 3)
            {
                return false;
            }

            var chainId = split[0] + ":" + split[1];
            return !string.IsNullOrWhiteSpace(split[2]) && IsValidChainId(chainId);
        }

        public static bool IsValidRequestExpiry(long expiry, long min, long max)
        {
            return expiry <= max && expiry >= min;
        }

        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
        {
            TSource[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new TSource[size];

                bucket[count++] = item;
                if (count != size)
                    continue;

                yield return bucket;

                bucket = null;
                count = 0;
            }

            if (bucket != null && count > 0)
                yield return bucket.Take(count).ToArray();
        }
    }
}