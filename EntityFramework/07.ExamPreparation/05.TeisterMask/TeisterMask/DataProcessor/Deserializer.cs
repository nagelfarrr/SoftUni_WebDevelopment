// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            ImportProjectDto[] xmlProjects;

            using(StringReader reader = new StringReader(xmlString))
            {
                xmlProjects = (ImportProjectDto[])serializer.Deserialize(reader);
            }

            List<Project> validProjects = new List<Project>();

            foreach (var xmlProject in xmlProjects)
            {
                bool isOpenDateValid = DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);
                bool isDueDateValid = DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectDueDate);

                if (!IsValid(xmlProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!isOpenDateValid || (!isDueDateValid && !string.IsNullOrWhiteSpace(xmlProject.DueDate)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? validProjectDueDate = string.IsNullOrWhiteSpace(xmlProject.DueDate) ? null : projectDueDate;

                Project validProject = new Project()
                {
                    Name = xmlProject.Name,
                    OpenDate = projectOpenDate,
                    DueDate = validProjectDueDate
                };

                

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    if (!IsValid(xmlTask))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    bool isTaskDueDateValid = DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if(!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(taskOpenDate < projectOpenDate || (validProjectDueDate != null && taskDueDate > validProjectDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task validTask = new Task()
                    {
                        Name = xmlTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)xmlTask.ExecutionType,
                        LabelType = (LabelType)xmlTask.LabelType,
                        ProjectId = validProject.Id
                    };

                    validProject.Tasks.Add(validTask);

                }

                validProjects.Add(validProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, validProject.Name, validProject.Tasks.Count));

            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportEmployeeDto[] jsonEmployees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> validEmployees = new List<Employee>();

            foreach (var jsonEmployee in jsonEmployees)
            {
                if (!IsValid(jsonEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee validEmployee = new Employee()
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                foreach (var taskId in jsonEmployee.Tasks.Distinct())
                {
                    if (!context.Tasks.Any(t=> t.Id == taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask et = new EmployeeTask()
                    {
                        TaskId = taskId,
                        Employee = validEmployee
                    };

                    validEmployee.EmployeesTasks.Add(et);
                }
                validEmployees.Add(validEmployee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, validEmployee.Username, validEmployee.EmployeesTasks.Count));
            }
            context.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}