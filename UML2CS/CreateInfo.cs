using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UML2CS{
    /// <summary>
    /// 生成するフォルダの情報管理
    /// </summary>
    public static class CreateInfo{
        public static string Namespace { get; private set; }

        public static void AddNameSpace(string nextNamespace){
            var s = "";
            if (!String.IsNullOrEmpty(Namespace)){
                s = "/";
            }

            Namespace += s + nextNamespace;
        }

        public static void BackDirectory(){
            for (int i = Namespace.Length - 1; i >= 0; i--){
                if (Namespace[i] == '/'){
                    Namespace = Namespace.Substring(0, i);
                    break;
                }
            }

            if (!Namespace.Contains('/')){
                Namespace = "";
            }
        }
    }
}