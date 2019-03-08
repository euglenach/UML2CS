using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

namespace UML2CS{
    /// <summary>
    /// UMLファイルをtxtファイルに変換するエディタ拡張
    /// </summary>
    public class Pu2TxtWindow : EditorWindow{
        [MenuItem("UML/Pu2Text")]
        public static void ShowWindow(){
            var path = "Assets/Resources/";
            if (AssetDatabase.IsValidFolder(path)){
                Debug.Log("No pu in Resources");
                return;
            }

            var pu = Directory.GetFiles(Application.dataPath + @"/Resources/")
                              .FirstOrDefault(n => Path.GetExtension(n) == ".pu"); //一番最初に取得したpuファイルだけ使う

            if (string.IsNullOrEmpty(pu)){
                Debug.Log("No pu in Resources");
                return;
            }

            var newPu = Application.dataPath + @"/Resources/" + Path.GetFileNameWithoutExtension(pu) + ".txt";
            
            File.Copy(pu, newPu);
            
            AssetDatabase.ImportAsset(path + Path.GetFileName(newPu));
        }
    }
}