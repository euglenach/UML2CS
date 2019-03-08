using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UML2CS{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class Extensions{
        public static IEnumerable<TKey> GetKeys<TKey, TValue>(this Dictionary<TKey, TValue> self){
            foreach (var item in self.Keys){
                yield return item;
            }
        }
        
        public static int CountOf(this string self, params string[] strArray){
            var count = 0;

            foreach (var str in strArray) {
                var index = self.IndexOf (str, 0);
                while (index != -1) {
                    count++;
                    index = self.IndexOf (str, index + str.Length);
                }
            }

            return count;
        }
    }
}