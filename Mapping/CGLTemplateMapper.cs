using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class CGLTemplateMapper
    {
        public List<TemplateDef> MapTemplateDef(IList<string> data)
        {
            int FieldLength = CGLTemplateFields.Fields.Length;
            var templates = new List<TemplateDef>();

            try
            {
                for(int i = 0; i < data.Count; i += FieldLength)
                {
                    var template = new TemplateDef();
                    if(Helper.CheckIfCorrectTemplateName(data[i + 1]))
                    {
                        template.TemplateName = data[i];
                        template.FieldName = data[i + 1];
                        template.FieldValue = data[i + 2];
                        template.FieldDesc = data[i + 3];
                        templates.Add(template);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return templates;
        }
    }
}
