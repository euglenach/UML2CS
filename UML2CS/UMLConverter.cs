using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor;

namespace UML2CS{
	/// <summary>
	/// UMLからC#に変換するクラス
	/// </summary>
	public class UMLConverter{
		private TextAsset umlFile;
		
		public UMLConverter(TextAsset umlFile){
			this.umlFile = umlFile;
		}
		
		public void Convert(){
			var blocks = new List<Block>();
			var lines = umlFile.text.Replace ("\r\n", "\n").Split ('\n'); //行ごとにわける

			var index = 0;
			foreach (var s in lines){
				
				if (s.Contains(" namespace ")){
					var name = GetTypeName(s);
					CreateInfo.AddNameSpace(name[1]); //"namespace XXXX"となっている前提
					SetContent.CreateFolder(CreateInfo.Namespace);
					blocks.Add(new Block(lines,index));
				}

				foreach (var item in UMLUtility.Contents){
					if (s.Contains(item)){
						var mono = "";
						var monoMethod = "";
						if (!(item == " interface " || item == " enum ")){
							mono = ": MonoBehaviour";
							monoMethod = UMLUtility.MonoMethod;
						}
						
						var typeNames = GetTypeName(s);

						var i = 1;
						var key = typeNames[0];
						if (item == " abstract class "){
							key += " " + typeNames[1];
							i = 2;
						}
						
						var code = UMLUtility.CodeTemplate.Replace("#TYPENAME#", UMLUtility.TypeNameTable[key])
						                     .Replace("#FILENAME#", typeNames[i])
						                     .Replace("#MonoBehaviour#", mono)
						                     .Replace("#MonoMethod#", monoMethod);
						
						SetContent.CreateFile(CreateInfo.Namespace,typeNames[i],code);
						break;
					}
				}
				if (blocks.Any()){
					if (blocks.Last().IsEnd(index)){ //namespaceが終わったかの判定
						CreateInfo.BackDirectory();
						blocks.RemoveAt(blocks.Count - 1);
					}
				}
				index++;
			}
			AssetDatabase.Refresh(); //エディターに反映
		}

		private string[] GetTypeName(string str){
			char[] separator = new char[] {' ','{','\t'};
			var words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();

			return words; //"namespace XXXX"みたいな返し方をする
		}
	}
}
