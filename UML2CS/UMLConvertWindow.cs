using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Assertions.Must;

namespace UML2CS{
	/// <summary>
	/// UMLからC#に変換するエディタ拡張のwindow生成部分
	/// </summary>
	public class UMLConvertWindow : EditorWindow{
		private static UMLConvertWindow window;
		[MenuItem("UML/UML2CS")]
		public static void ShowWindow(){
			window = CreateInstance<UMLConvertWindow>();
			window.titleContent = new GUIContent("UMLConverter");
			window.ShowUtility();
			
		}

		private TextAsset umlFile;
		
		private void OnGUI(){
			EditorGUILayout.BeginHorizontal();
			{
				EditorGUILayout.LabelField ("ClassDiagram", GUILayout.MaxWidth (100));
				umlFile = EditorGUILayout.ObjectField (umlFile, typeof (TextAsset), false) as TextAsset;
			}
			EditorGUILayout.EndHorizontal ();
			
			EditorGUILayout.BeginHorizontal ();
			{
				if (GUILayout.Button("Create")){ //ファイルが無いと警告
					if (umlFile == null){
						Debug.LogError("No File");
						return;
					}
					var converter = new UMLConverter(umlFile);
					converter.Convert();
				}
			}
		}
	}
}
