namespace SoMeTech.WebServerAccess
{
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Net;
    using System.Reflection;
    using System.Web.Services.Description;
    using System.Xml.Serialization;

    public sealed class ServerCollections
    {
        public object DoServerCollections(string webserverUrl, string protocolName, string accessWebserverDllName, string accessWebserverClassName, string webserverMethod, object[] methodParams)
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
                OutputAssembly = accessWebserverDllName + ".dll"
            };
            options.ReferencedAssemblies.Add("System.dll");
            options.ReferencedAssemblies.Add("System.XML.dll");
            options.ReferencedAssemblies.Add("System.Web.Services.dll");
            options.ReferencedAssemblies.Add("System.Data.dll");
            if (provider.CompileAssemblyFromDom(options, new CodeCompileUnit[] { codeCompileUnit }).Errors.HasErrors)
            {
                return "NO";
            }
            Type type = Assembly.LoadFrom(accessWebserverDllName + ".dll").GetType(accessWebserverClassName);
            object obj2 = Activator.CreateInstance(type);
            return type.GetMethod(webserverMethod).Invoke(obj2, methodParams);
        }
    }
}

