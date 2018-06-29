using Microsoft.Extensions.Configuration;

namespace Salaros.Configuration.IniLike
{
    public class IniLikeConfigurationSource : FileConfigurationSource
    {
        /// <summary>
        /// Builds the <see cref="T:CodeCave.Extensions.Configuration.Ini.IniConfigurationProvider" /> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="T:CodeCave.Extensions.Configuration.Ini.IniConfigurationProvider" />.</param>
        /// <returns>
        /// An <see cref="T:CodeCave.Extensions.Configuration.Ini.IniConfigurationProvider" />
        /// </returns>
        /// <inheritdoc />
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new IniLikeConfigurationProvider(this);
        }
    }
}
