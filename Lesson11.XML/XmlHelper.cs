using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lesson11.XML
{
    class XmlHelper
    {
        private readonly string _fileName;

        public XmlHelper(string fileName)
        {
            _fileName = fileName;
        }

        public void CreateFile()
        {
            var writer = new XmlTextWriter(_fileName, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("employees");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            Console.WriteLine("File was created.");
        }

        public void Save(Employee employee)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_fileName);

                var root = doc.CreateElement("employee");
                doc.DocumentElement?.AppendChild(root);

                var attr = doc.CreateAttribute("id");
                attr.Value = $"{employee.Id}";
                root.Attributes.Append(attr);

                var name = doc.CreateElement("name");
                name.InnerText = employee.Name;
                root.AppendChild(name);

                var age = doc.CreateElement("age");
                age.InnerText = $"{employee.Age}";
                root.AppendChild(age);

                var address = doc.CreateElement("address");
                address.InnerText = employee.Address;
                root.AppendChild(address);

                var salary = doc.CreateElement("salary");
                salary.InnerText = $"{employee.Salary}";
                root.AppendChild(salary);

                doc.Save(_fileName);

                Console.WriteLine("Employee was saved to file.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Employee> LoadEmployees()
        {
            try
            {
                var items = new List<Employee>();

                var doc = new XmlDocument();
                doc.Load(_fileName);

                var employeeNodes = doc.GetElementsByTagName("employee");
                if (employeeNodes.Count == 0) return items;

                foreach (XmlElement employeeRoot in employeeNodes)
                {
                    var employee = new Employee();
                    var idAttr = employeeRoot.Attributes["id"].Value;
                    if (!string.IsNullOrWhiteSpace(idAttr))
                    {
                        if (Guid.TryParse(idAttr, out var id))
                        {
                            employee.Id = id;
                        }
                    }

                    foreach (XmlElement employeeProps in employeeRoot)
                    {
                        switch (employeeProps.Name)
                        {
                            case "name":
                                employee.Name = employeeProps.InnerText;
                                break;
                            case "address":
                                employee.Address = employeeProps.InnerText;
                                break;
                            case "age":
                                if (int.TryParse(employeeProps.InnerText, out var age))
                                {
                                    employee.Age = age;
                                }
                                break;
                            case "salary":
                                if (double.TryParse(employeeProps.InnerText, out var salary))
                                {
                                    employee.Salary = salary;
                                }
                                break;
                        }
                    }

                    items.Add(employee);
                }

                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string employeeId)
        {
            var doc = new XmlDocument();
            doc.Load(_fileName);

            var employeeNodes = doc.GetElementsByTagName("employee");
            if (employeeNodes.Count == 0) return;

            foreach (XmlElement employeeRoot in employeeNodes)
            {
                var id = employeeRoot.Attributes["id"].Value;
                if (string.IsNullOrWhiteSpace(id)) continue;               
                if (!employeeId.Equals(id)) continue;

                var parent = employeeRoot.ParentNode;
                parent?.RemoveChild(employeeRoot);

                Console.WriteLine("Employee was deleted.");
                break;
            }

            doc.Save(_fileName);
        }

        public void Edit(Employee employee)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_fileName);

                var employeeNodes = doc.GetElementsByTagName("employee");
                if (employeeNodes.Count == 0) return;

                foreach (XmlElement employeeRoot in employeeNodes)
                {
                    var idAttr = employeeRoot.Attributes["id"].Value;
                    if (string.IsNullOrWhiteSpace(idAttr)) continue;
                    if (!Guid.TryParse(idAttr, out var id)) continue;
                    if(!employee.Id.Equals(id)) continue;

                    foreach (XmlElement employeeProps in employeeRoot)
                    {
                        switch (employeeProps.Name)
                        {
                            case "name":
                                employeeProps.InnerText = employee.Name;
                                break;
                            case "address":
                                employeeProps.InnerText = employee.Address;
                                break;
                            case "age":
                                employeeProps.InnerText = $"{employee.Age}";
                                break;
                            case "salary":
                                employeeProps.InnerText = $"{employee.Salary}";
                                break;
                        }
                    }

                    Console.WriteLine("Changes were saved.");
                    break;
                }

                doc.Save(_fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
