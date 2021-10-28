using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using midTerm.Data.DataTransferObjects;

namespace SurveySystem
{
    public class CsvOutputFormatters : TextOutputFormatter
    {
        public CsvOutputFormatters()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(SurveyUserDto).IsAssignableFrom(type) || typeof(IEnumerable<SurveyUserDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<SurveyUserDto>)
            {
                foreach (var surveyUserDto in (IEnumerable<SurveyUserDto>)context.Object)
                {
                    FormatCsv(buffer, surveyUserDto);
                }
            }

            else
            {
                FormatCsv(buffer, (SurveyUserDto)context.Object);
            }

        }

        private static void FormatCsv(StringBuilder buffer, SurveyUserDto surveyUserDto)
        {
            buffer.AppendLine(
                $"{surveyUserDto.Id},\"{surveyUserDto.FirstName},\"{surveyUserDto.LastName},\"{surveyUserDto.Country},\"{surveyUserDto.DoB},\"{surveyUserDto.Gender}\"");

        }
    }
}
