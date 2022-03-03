using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using NamingConventions = YamlDotNet.Serialization.NamingConventions;

namespace YamlSerialization
{
    public class YamlSerializer : ISerializer
    {
        private Serializer Serializer { get; init; }

        public YamlSerializer()
        {
            Serializer = (Serializer)new SerializerBuilder()
                .WithNamingConvention(NamingConventions.CamelCaseNamingConvention.Instance)
                .IncludeNonPublicProperties()
                .Build();
        }

        public string Serialize(object obj)
        {
            return Serializer.Serialize(obj);
        }
    }
}
