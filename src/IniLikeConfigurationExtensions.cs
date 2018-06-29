using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Salaros.Configuration.IniLike
{
    /// <summary>
    /// Extension methods for adding <see cref="IniLikeConfigurationProvider"/>.
    /// </summary>
    public static class IniLikeConfigurationExtensions
    {
        /// <summary>
        /// Adds the text (*.ini|cnf|conf|cfg) configuration provider at <paramref name="path" /> to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder" /> to add to.</param>
        /// <param name="path">Path relative to the base path stored in
        /// <see cref="IConfigurationBuilder.Properties" /> of <paramref name="builder" />.</param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder" />.
        /// </returns>
        public static IConfigurationBuilder AddIniLikeConfig(this IConfigurationBuilder builder, string path)
        {
            return AddIniLikeConfig(builder, provider: null, path: path, optional: false, reloadOnChange: false);
        }

        /// <summary>
        /// Adds the text (*.ini|cnf|conf|cfg) configuration provider at <paramref name="path" /> to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder" /> to add to.</param>
        /// <param name="path">Path relative to the base path stored in
        /// <see cref="IConfigurationBuilder.Properties" /> of <paramref name="builder" />.</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder" />.
        /// </returns>
        public static IConfigurationBuilder AddIniLikeConfig(this IConfigurationBuilder builder, string path, bool optional)
        {
            return AddIniLikeConfig(builder, provider: null, path: path, optional: optional, reloadOnChange: false);
        }

        /// <summary>
        /// Adds the text (*.ini|cnf|conf|cfg) configuration provider at <paramref name="path" /> to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder" /> to add to.</param>
        /// <param name="path">Path relative to the base path stored in
        /// <see cref="IConfigurationBuilder.Properties" /> of <paramref name="builder" />.</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder" />.
        /// </returns>
        public static IConfigurationBuilder AddIniLikeConfig(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
        {
            return AddIniLikeConfig(builder, provider: null, path: path, optional: optional, reloadOnChange: reloadOnChange);
        }

        /// <summary>
        /// Adds a text (*.ini|cnf|conf|cfg) configuration source to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder" /> to add to.</param>
        /// <param name="provider">The <see cref="IFileProvider" /> to use to access the file.</param>
        /// <param name="path">Path relative to the base path stored in
        /// <see cref="IConfigurationBuilder.Properties" /> of <paramref name="builder" />.</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">builder</exception>
        /// <exception cref="ArgumentException">File path must be a non-empty string. - path</exception>
        public static IConfigurationBuilder AddIniLikeConfig(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("File path must be a non-empty string.", nameof(path));

            return builder.AddIniLikeConfig(s =>
            {
                s.FileProvider = provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        /// <summary>
        /// Adds a text (*.ini|cnf|conf|cfg) configuration source to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder" /> to add to.</param>
        /// <param name="configureSource">Configures the source.</param>
        /// <returns>
        /// The <see cref="IConfigurationBuilder" />.
        /// </returns>
        public static IConfigurationBuilder AddIniLikeConfig(this IConfigurationBuilder builder, Action<IniLikeConfigurationSource> configureSource)
            => builder.Add(configureSource);
    }
}
