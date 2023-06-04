using System;
using System.Text.RegularExpressions;

namespace lab123.Models
{
    public class Data
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int Pressure { get; set; }
        public int WindSpeed { get; set; }
        public string Humidity { get; set; }

        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();
            Regex regexHumidity = new Regex(@"0%|[1-9][0-9]%|100%");
            MatchCollection matches = regexHumidity.Matches(Humidity);

            if (TemperatureC < -40 || TemperatureC > 60) validationResult.Append($"TemperatureC {TemperatureC} is out of range (-40..60)");
            if (Pressure < 730 || Pressure > 770) validationResult.Append($"Pressure {Pressure} is out of range (730..770)");
            if (WindSpeed < 0 || WindSpeed > 100) validationResult.Append($"WindSpeed {WindSpeed} is out of range (0..100)");
            if (string.IsNullOrWhiteSpace(Humidity)) validationResult.Append($"Humidity cannot be empty");

            if (matches.Count == 0)
            {
                validationResult.Append($"Humidity {Humidity} should be written in the format: 0-100%");
            }


            return validationResult;
        }
    }
}
