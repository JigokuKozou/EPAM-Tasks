using SuperString;

Console.WriteLine("Примеры:");
string example = "Русский";
Console.WriteLine(example + " " + example.GetLanguage());

example = "English";
Console.WriteLine(example + " " + example.GetLanguage());

example = "Mixed миксированный";
Console.WriteLine(example + " " + example.GetLanguage());

example = "Mixed,";
Console.WriteLine(example + " " + example.GetLanguage());

example = "Mixed ";
Console.WriteLine(example + " " + example.GetLanguage());