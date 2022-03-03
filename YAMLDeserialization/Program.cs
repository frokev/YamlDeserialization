
using Examples.Models.Test;
using YamlSerialization;

var deserializer = new YamlDeserializer();
var serializer = new YamlSerializer();

var person = deserializer.DeserializeByFilePath<Person>(@"Configuration\Person.yaml");

Console.WriteLine(person.ToString(serializer));
