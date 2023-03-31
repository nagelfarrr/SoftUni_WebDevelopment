namespace TeisterMask.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var projects = context.Projects
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectDto()
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count(),
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks
                        .Select(t => new ExportTaskDto()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString(),
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            using(StringWriter sw = new StringWriter(sb)) 
            { 
                serializer.Serialize(sw, projects, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employyes = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et=> et.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d" , CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        
                        .ToArray()
                })
                .OrderByDescending(e=> e.Tasks.Count())
                .ThenBy(e=> e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employyes, Formatting.Indented);
        }
    }
}