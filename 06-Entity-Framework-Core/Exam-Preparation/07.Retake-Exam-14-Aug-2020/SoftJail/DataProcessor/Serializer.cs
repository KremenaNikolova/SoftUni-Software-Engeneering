namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p=> new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po=> new
                    {
                        OfficerName = po.Officer.FullName,
                        Department= po.Officer.Department.Name
                    })
                    .OrderBy(o=>o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po=>po.Officer.Salary), 2)
                })
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            StringBuilder sb = new StringBuilder();

            string[] names = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();


            var prisoners = context.Prisoners
                .Where(p=>names.Contains(p.FullName))
                .Select(p=> new ExportPrisonerDto()
                {
                    Id= p.Id,
                    FullName= p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m=> new ExportMailDto()
                    {
                        Description= string.Join("", m.Description.Reverse().ToArray())
                    })
                    .ToArray()
                })
                .OrderBy(p=>p.FullName)
                .ThenBy(p=>p.Id)
                .ToArray();


            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPrisonerDto[]), xmlRoot);

            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}