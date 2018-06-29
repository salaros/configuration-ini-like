using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Salaros.Config;

namespace Salaros.Configuration.IniLike
{
    public class IniLikeConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance with the specified source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        /// <inheritdoc />
        /// ReSharper disable once SuggestBaseTypeForParameter
        public IniLikeConfigurationProvider(IniLikeConfigurationSource source) : base(source) { }

        /// <summary>
        /// Loads the config file data from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <inheritdoc />
        public override void Load(Stream stream)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (var reader = new StreamReader(stream))
            {
                var configFileContent = reader.ReadToEnd();
                var configParser = new ConfigParser(configFileContent);
                foreach (var section in configParser.Sections)
                {
                    var sectionPrefix = $"{section.SectionName}{ConfigurationPath.KeyDelimiter}";
                    foreach (var key in section.Keys)
                    {
                        var keyName = $"{sectionPrefix}{key.Name}";
                        var value = section[key.Name];
                        data.Add(keyName, value);
                    }
                }
            }

            Data = data;
        }
    }
}
