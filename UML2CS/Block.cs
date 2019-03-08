namespace UML2CS{
    /// <summary>
    /// 各Namespace管理クラス
    /// </summary>
    public class Block{
        private int startBlockCount = 0;
        private int endBlockCount = 0;
        public int EndLine { get; private set; }
        
        public Block(string[] umlCode,int startLine){
            var i = 0;
            foreach (var s in umlCode){
                if (i < startLine){
                    i++;
                    continue;
                }
                startBlockCount += s.CountOf("{");
                endBlockCount += s.CountOf("}");
                if ((startBlockCount == endBlockCount) && startBlockCount != 0) break;
                i++;
            }
            EndLine = i;
        }

        public bool IsEnd(int nowLine){
             return nowLine >= EndLine;
         }
     }
 }