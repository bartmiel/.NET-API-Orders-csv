using CsvHelper;
using CsvHelper.Configuration;
using NetlandRecruitingTask.Application.Contracts;
using System.Globalization;
using System.Text;

namespace NetlandRecruitingTask.Infrastructure.Repositories
{
    //Klasa odpowiada za odczytanie pliku csv - korzystam z paczki NuGet csvHelper
    public class CsvRepository : ICsvRepository
    {
        public async Task<IEnumerable<T>> ReadCSVAsync<T>(string pathFile)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                //Konfiguracja dzialania paczki
                HasHeaderRecord = true,
                Delimiter = ",",
                Quote = '"',
                IgnoreBlankLines = true,
                HeaderValidated = null,
                BadDataFound = context => Console.WriteLine($"Bad data found on row {context.RawRecord}"),
                Encoding = Encoding.UTF8,
        };
            var reader = new StreamReader(pathFile);
            var csv = new CsvReader(reader, configuration);
            //Schemat mapowania pol - ustawiam tam format daty uzywany w pliku csv
            csv.Context.RegisterClassMap<OrderMap>();

            var records = new List<T>();

            await foreach(var record in csv.GetRecordsAsync<T>())
            {
                records.Add(record);
            }

            return records;
        }
    }
}