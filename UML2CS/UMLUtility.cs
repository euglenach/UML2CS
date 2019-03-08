using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UML2CS{
	/// <summary>
	/// UMLからC#に変換する情報
	/// </summary>
	public class UMLUtility{
		public static readonly Dictionary<string, string> TypeNameTable = new Dictionary<string, string>(){
			{"class", "class"},
			{"abstract", "abstract class"},
			{"abstract class","abstract class"},
			{"interface", "interface"},
			{"enum", "enum"},
		};

		public static readonly string[] Contents = {
			" abstract class "," class "," abstract "," interface "," enum "
		};
		
		public static readonly string CodeTemplate = 
@"using UnityEngine;
		
public #TYPENAME# #FILENAME# #MonoBehaviour# {
	#MonoMethod#
}
";

		public static readonly string MonoMethod =
@"private void Update(){
			
	}
	private void Start(){
			
	}
";
		
		
	}
}