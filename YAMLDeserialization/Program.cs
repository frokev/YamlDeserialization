
using Examples.Models.Test;
using YamlSerialization;

var deserializer = new YamlDeserializer();
var serializer = new YamlSerializer();

deserializer.AddTagMapping("!hobby", typeof(Hobby));

var person = deserializer.DeserializeByFilePath<Person>(@"Configuration\Person.yaml");

Console.WriteLine(person.ToString(serializer));
