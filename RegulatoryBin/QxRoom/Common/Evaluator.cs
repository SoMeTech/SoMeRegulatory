namespace QxRoom.Common
{
    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;

    public class Evaluator
    {
        private static object _evaluator = null;
        private static Type _evaluatorType = null;
        private static readonly string _jscriptSource = "class Evaluator\r\n              {\r\n                  public function Eval(expr : String) : String \r\n                  { \r\n                     return eval(expr); \r\n                  }\r\n              }";

        static Evaluator()
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("JScript");
            CompilerParameters options = new CompilerParameters {
                GenerateInMemory = true
            };
            _evaluatorType = provider.CompileAssemblyFromSource(options, new string[] { _jscriptSource }).CompiledAssembly.GetType("Evaluator");
            _evaluator = Activator.CreateInstance(_evaluatorType);
        }

        public static object Eval(string statement)
        {
            return _evaluatorType.InvokeMember("Eval", BindingFlags.InvokeMethod, null, _evaluator, new object[] { statement });
        }
    }
}

