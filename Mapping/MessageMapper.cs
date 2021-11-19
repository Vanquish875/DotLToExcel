using DotLToExcel.DotL;
using DotLToExcel.POCOS;
using System;
using System.Collections.Generic;

namespace DotLToExcel.Mapping
{
    public class MessageMapper
    {
        public (IEnumerable<Message> messages, Dictionary<string, string> outputMessages) MapMessages(IList<string> data)
        {
            int FieldLength = MessageFields.Fields.Length;
            var messages = new List<Message>();
            var outputMessages = new Dictionary<string, string>();

            try
            {
                for (int i = 0; i < data.Count; i += FieldLength)
                {
                    CreateMessage(data, messages, outputMessages, i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (messages, outputMessages);
        }

        private static void CreateMessage(IList<string> data, List<Message> messages, Dictionary<string, string> outputMessages, int i)
        {
            var message = new Message();
            message.name = data[i];
            message.setName = data[i + 1];
            message.fg = data[i + 2];
            message.severity = data[i + 3];
            message.txt = data[i + 4];
            message.image = data[i + 5];
            message.rawValue = data[i + 6];
            if (data[i + 6].Equals("1") || data[i + 6].Equals("2"))
            {
                outputMessages.Add(data[i], data[i + 4]);
            }
            messages.Add(message);
        }
    }
}
