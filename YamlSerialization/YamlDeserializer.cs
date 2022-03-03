using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YamlSerialization
{
    public class YamlDeserializer
    {
        private Deserializer Deserializer { get; set; }
        private DeserializerBuilder DeserializerBuilder { get; set; }

        public YamlDeserializer()
        {
            DeserializerBuilder = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IncludeNonPublicProperties();
            
            Deserializer = (Deserializer)DeserializerBuilder.Build();
        }

        public void AddTagMapping(string tagName, Type type)
        {
            DeserializerBuilder.WithTagMapping(tagName, type);
        }

        public T Deserialize<T>(string input)
        {
            Deserializer = (Deserializer)DeserializerBuilder.Build();
            return Deserializer.Deserialize<T>(input);
        }

        public T DeserializeByFilePath<T>(string fileAppRelativeUrl)
        {
            using var streamReader = new StreamReader(
                    new FileStream(fileAppRelativeUrl, FileMode.Open, FileAccess.Read)
                );

            var content = streamReader.ReadToEnd();

            return Deserialize<T>(content);
        }
    }
}
