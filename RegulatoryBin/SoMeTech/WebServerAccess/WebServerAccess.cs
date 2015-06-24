namespace SoMeTech.WebServerAccess
{
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Net;
    using System.Web.Services.Description;
    using System.Xml.Serialization;

    public sealed class WebServerAccess
    {
        public object DoWebServerAccess(string webserverUrl, string webserverClassName, string webserverMethod)
        {
            return this.WebServerAccessMethod(webserverUrl, "Soap", webserverClassName, webserverMethod, null);
        }

        public object DoWebServerAccess(string webserverUrl, string webserverClassName, string webserverMethod, object[] methodParams)
        {
            return this.WebServerAccessMethod(webserverUrl, "Soap", webserverClassName, webserverMethod, methodParams);
        }

        public object DoWebServerAccess(string webserverUrl, string protocolName, string webserverClassName, string webserverMethod, object[] methodParams)
        {
            return this.WebServerAccessMethod(webserverUrl, protocolName, webserverClassName, webserverMethod, methodParams);
        }

        private object WebServerAccessMethod(string webserverUrl, string protocolName, string webserverClassName, string webserverMethod, object[] methodParams)
        {
            WebClient client = new WebClient();
            ServiceDescription serviceDescription = ServiceDescription.Read(client.OpenRead(webserverUrl + "?WSDL"));
            ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
            if (protocolName != "")
            {
                importer.ProtocolName = protocolName;
            }
            else
            {
                importer.ProtocolName = "Soap";
            }
            importer.Style = ServiceDescriptionImportStyle.Client;
            importer.CodeGenerationOptions = CodeGenerationOptions.GenerateNewAsync | CodeGenerationOptions.GenerateProperties;
            importer.AddServiceDescription(serviceDescription, null, null);
            CodeNamespace namespace2 = new CodeNamespace();
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
            codeCompileUnit.Namespaces.Add(namespace2);
            importer.Import(namespace2, codeCompileUnit);
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters options = new CompilerParameters {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            options.ReferencedAssemblies.Add("System.dll");
            options.ReferencedAssemblies.Add("System.XML.dll");
            options.ReferencedAssemblies.Add("System.Web.Services.dll");
            options.ReferencedAssemblies.Add("System.Data.dll");
            CompilerResults results = provider.CompileAssemblyFromDom(options, new CodeCompileUnit[] { codeCompileUnit });
            if (results.Errors.HasErrors)
            {
                return "NO";
            }
            Type type = results.CompiledAssembly.GetType(webserverClassName);
            object obj2 = Activator.CreateInstance(type);
            return type.GetMethod(webserverMethod).Invoke(obj2, methodParams);
        }
    }
}

