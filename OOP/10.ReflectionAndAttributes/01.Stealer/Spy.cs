namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {


        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {

            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (var fieldInfo in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");

            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);

            FieldInfo[] classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            
            foreach (var classField in classFields)
            {
                sb.AppendLine($"{classField.Name} must be private");
            }

            foreach (var methodInfo in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} have to be public!");
            }

            foreach (var classPublicMethod in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{classPublicMethod.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] classPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var privateMethod in classPrivateMethods)
            {
                sb.AppendLine($"{privateMethod.Name}");
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] classMethods =
                type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var sb = new StringBuilder();

            foreach (var classMethod in classMethods.Where( m=> m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{classMethod.Name} will return {classMethod.ReturnType}");
            }

            foreach (var methodInfo in classMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine(
                    $"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
        
    }
}
