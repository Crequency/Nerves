﻿using System.Text.Json;

namespace Nerves.Shared.Configs;

public class ConfigBase
{

}

public static class ConfigBaseExtensions
{
    private static readonly JsonSerializerOptions serializationOptions = new()
    {
        WriteIndented = true,
    };

    public static ConfigBase Load<T>(this string path) where T : ConfigBase, new()
    {
        path = Path.GetFullPath(path);

        if (!File.Exists(path))
        {
            var dir = Path.GetDirectoryName(path);

            if (!Directory.Exists(dir) && dir is not null)
                Directory.CreateDirectory(dir);

            new T().Save(path);
        }

        return JsonSerializer.Deserialize<T>(
            File.ReadAllText(Path.GetFullPath(path))
        ) ?? throw new Exception("Can not deserialize config file.");
    }

    public static void Save<T>(this T config, string path) where T : ConfigBase
    {
        path = Path.GetFullPath(path);

        var text = JsonSerializer.Serialize(config, serializationOptions);

        File.WriteAllText(path, text);
    }
}
