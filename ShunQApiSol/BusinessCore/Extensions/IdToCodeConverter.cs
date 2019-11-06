using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Extensions
{
  public  class IdToCodeConverter
    {
        const string CODE_STR = "XABCDEFGHIJKLMNOPQRSTUVWYZ";

        public string ToCode(long id)
        {
            var code = string.Empty;
            char pChar = ' ';
            var cCount = 1;
            foreach (var c in id.ToString())
            {
                if (pChar == c)
                    cCount++;
                else
                {
                    if (cCount > 1)
                        code += cCount;

                    code += CODE_STR[int.Parse(c + "")];
                    cCount = 1;
                    pChar = c;
                }
            }
            if (cCount > 1)
                code += cCount;
            return code;
        }

        public long ToId(string code)
        {
            string id = "";
            char pChar = ' ';
            foreach (char c in code)
            {
                if (char.IsNumber(c))
                {
                    var num = int.Parse(c + "") - 1;
                    var cNum = CODE_STR.IndexOf(pChar);
                    id = id.PadRight(id.Length + num, (cNum + "")[0]);
                }
                else
                {
                    id += CODE_STR.IndexOf(c);
                    pChar = c;
                }
            }
            if (id == "")
                return 0;
            return long.Parse(id);
        }
    }
}
