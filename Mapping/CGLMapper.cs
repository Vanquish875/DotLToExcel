using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotLToExcel.Mapping
{
    public class CGLMapper
    {
        public IEnumerable<CGLTemplateDef> MapCGLTemplate(List<TemplateDef> data)
        {
            var templates = new List<CGLTemplateDef>();

            try
            {
                var names = data.Select(i => i.TemplateName).Distinct();

                foreach (var name in names)
                {
                    var configs = data.Where(i => i.TemplateName == name);

                    var template = new CGLTemplateDef();
                    template.TemplateName = name;
                    foreach (var config in configs)
                    {
                        switch (config.FieldName)
                        {
                            case "Upload.METER.Periodic.HOURLY.Run[01].DPPLoadType":
                                template.Hourly1AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[01].Data.RecordLast":
                                template.Hourly1Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[01].Data.RegRW":
                                template.Hourly1Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[01].Index.RegRW":
                                template.Hourly1Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[01].DPPLoadType":
                                template.Daily1AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[01].Data.RecordLast":
                                template.Daily1Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[01].Data.RegRW":
                                template.Daily1Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[01].Index.RegRW":
                                template.Daily1Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[02].DPPLoadType":
                                template.Hourly2AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[02].Data.RecordLast":
                                template.Hourly2Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[02].Data.RegRW":
                                template.Hourly2Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[02].Index.RegRW":
                                template.Hourly2Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[02].DPPLoadType":
                                template.Daily2AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[02].Data.RecordLast":
                                template.Daily2Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[02].Data.RegRW":
                                template.Daily2Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[02].Index.RegRW":
                                template.Daily2Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[03].DPPLoadType":
                                template.Hourly3AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[03].Data.RecordLast":
                                template.Hourly3Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[03].Data.RegRW":
                                template.Hourly3Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[03].Index.RegRW":
                                template.Hourly3Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[03].DPPLoadType":
                                template.Daily3AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[03].Data.RecordLast":
                                template.Daily3Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[03].Data.RegRW":
                                template.Daily3Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[03].Index.RegRW":
                                template.Daily3Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[04].DPPLoadType":
                                template.Hourly4AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[04].Data.RecordLast":
                                template.Hourly4Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[04].Data.RegRW":
                                template.Hourly4Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[04].Index.RegRW":
                                template.Hourly4Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[04].DPPLoadType":
                                template.Daily4AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[04].Data.RecordLast":
                                template.Daily4Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[04].Data.RegRW":
                                template.Daily4Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[04].Index.RegRW":
                                template.Daily4Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[05].DPPLoadType":
                                template.Hourly5AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[05].Data.RecordLast":
                                template.Hourly5Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[05].Data.RegRW":
                                template.Hourly5Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[05].Index.RegRW":
                                template.Hourly5Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[05].DPPLoadType":
                                template.Daily5AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[05].Data.RecordLast":
                                template.Daily5Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[05].Data.RegRW":
                                template.Daily5Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[05].Index.RegRW":
                                template.Daily5Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[06].DPPLoadType":
                                template.Hourly6AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[06].Data.RecordLast":
                                template.Hourly6Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[06].Data.RegRW":
                                template.Hourly6Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[06].Index.RegRW":
                                template.Hourly6Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[06].DPPLoadType":
                                template.Daily6AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[06].Data.RecordLast":
                                template.Daily6Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[06].Data.RegRW":
                                template.Daily6Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[06].Index.RegRW":
                                template.Daily6Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[07].DPPLoadType":
                                template.Hourly7AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[07].Data.RecordLast":
                                template.Hourly7Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[07].Data.RegRW":
                                template.Hourly7Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[07].Index.RegRW":
                                template.Hourly7Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[07].DPPLoadType":
                                template.Daily7AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[07].Data.RecordLast":
                                template.Daily7Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[07].Data.RegRW":
                                template.Daily7Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[07].Index.RegRW":
                                template.Daily7Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[08].DPPLoadType":
                                template.Hourly8AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[08].Data.RecordLast":
                                template.Hourly8Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[08].Data.RegRW":
                                template.Hourly8Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[08].Index.RegRW":
                                template.Hourly8Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[08].DPPLoadType":
                                template.Daily8AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[08].Data.RecordLast":
                                template.Daily8Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[08].Data.RegRW":
                                template.Daily8Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[08].Index.RegRW":
                                template.Daily8Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[09].DPPLoadType":
                                template.Hourly9AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[09].Data.RecordLast":
                                template.Hourly9Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[09].Data.RegRW":
                                template.Hourly9Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.HOURLY.Run[09].Index.RegRW":
                                template.Hourly9Register = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[09].DPPLoadType":
                                template.Daily9AGA = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[09].Data.RecordLast":
                                template.Daily9Size = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[09].Data.RegRW":
                                template.Daily9Array = config.FieldValue;
                                break;
                            case "Upload.METER.Periodic.DAILY.Run[09].Index.RegRW":
                                template.Daily9Register = config.FieldValue;
                                break;
                            default:
                                break;
                        }
                    }
                    templates.Add(template);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return templates;
        }
    }
}
