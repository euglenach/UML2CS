using UnityEditor;
using System.IO;
using System.Linq;
using UnityEngine;

namespace UML2CS{
	/// <summary>
	/// フォルダとかファイル生成用クラス
	/// </summary>
	public static class SetContent{
		public static void CreateFolder(string folderName){
			if (string.IsNullOrEmpty(folderName)) return;
			var path = "Assets/Scripts/" + folderName;
			if (AssetDatabase.IsValidFolder(path)) return; //すでにあったら終わり
		
			Directory.CreateDirectory(path);
			AssetDatabase.ImportAsset(path);
		}

		public static void CreateFile(string path,string fileName,string code){
			var p = "Assets/Scripts/" + path + "/" + fileName + ".cs";
			var assetPath = AssetDatabase.GenerateUniqueAssetPath(p);
			File.WriteAllText(assetPath, code);
		}
	}
}