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
        private Deserializer Deserializer { get; init; }

        public YamlDeserializer()
        {
            var builder = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IncludeNonPublicProperties();

            Deserializer = (Deserializer)builder.Build();
        }

        public T Deserialize<T>(string input)
        {
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
