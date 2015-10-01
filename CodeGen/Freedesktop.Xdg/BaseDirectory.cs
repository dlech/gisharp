using System;
using System.IO;
using System.Linq;

namespace Freedesktop.Xdg
{
    /// <summary>
    /// XDG Base directories.
    /// </summary>
    /// <remarks>
    /// Based on http://standards.freedesktop.org/basedir-spec/basedir-spec-0.8.html.
    /// </remarks>
    public static class BaseDirectory
    {
        /// <summary>
        /// Gets the directory where user-specific data files are stored.
        /// </summary>
        /// <value>The full path of the directory.</value>
        /// <remarks>
        /// Uses the <c>XDG_DATA_HOME</c> environment variable if set and
        /// non-empty or <c>$HOME/.local/share</c> otherwise.
        /// </remarks>
        public static string DataHome {
            get {
                var dir = Environment.GetEnvironmentVariable ("XDG_DATA_HOME");
                if (string.IsNullOrWhiteSpace (dir)) {
                    dir = Path.Combine (
                        Environment.GetFolderPath (Environment.SpecialFolder.UserProfile),
                        ".local",
                        "share");
                }
                return dir;
            }
        }

        /// <summary>
        /// Gets the directory where user-specific config files are stored.
        /// </summary>
        /// <value>The the full path of the directory.</value>
        /// <remarks>
        /// Uses the <c>XDG_CONFIG_HOME</c> environmet variable if set and
        /// non-empty or <c>$HOME/.config</c> otherwise.
        /// </remarks>
        public static string ConfigHome {
            get {
                var dir = Environment.GetEnvironmentVariable ("XDG_CONFIG_HOME");
                if (string.IsNullOrWhiteSpace (dir)) {
                    dir = Path.Combine (
                        Environment.GetFolderPath (Environment.SpecialFolder.UserProfile),
                        ".config");
                }
                return dir;
            }
        }

        /// <summary>
        /// Gets a list of directories to search for data files in addition to
        /// <see cref="DataHome"/>.
        /// </summary>
        /// <value>The data directories.</value>
        /// <remarks>
        /// Uses the <c>XDG_DATA_DIRS</c> environment variable if set and
        /// non-empty or <c>/usr/local/share</c>, <c>/usr/share</c> otherwise;
        public static string[] DataDirs {
            get {
                var dirs = Environment.GetEnvironmentVariable ("XDG_DATA_DIRS");
                if (string.IsNullOrWhiteSpace (dirs)) {
                    dirs = string.Join (Path.PathSeparator.ToString (),
                        Path.Combine (Path.DirectorySeparatorChar.ToString (),
                            "usr", "local", "share"),
                        Path.Combine (Path.DirectorySeparatorChar.ToString (),
                            "usr", "share"));
                }
                return dirs.Split (Path.PathSeparator);
            }
        }

        /// <summary>
        /// Gets a list of directories to search for configuration files in
        /// addition to <see cref="ConfigHome"/>.
        /// </summary>
        /// <value>The configuration directories.</value>
        /// <remarks>
        /// Uses the <c>XDG_CONFIG_DIRS</c> environment variable if set and
        /// non-empty or <c>/etc/xdg</c> otherwise.
        /// </remarks>
        public static string[] ConfigDirs {
            get {
                var dirs = Environment.GetEnvironmentVariable ("XDG_CONFIG_DIRS");
                if (string.IsNullOrWhiteSpace (dirs)) {
                    dirs = Path.Combine (Path.DirectorySeparatorChar.ToString (),
                        "etc", "xdg");
                }
                return dirs.Split (Path.PathSeparator);
            }
        }

        /// <summary>
        /// Gets the path for user-specific non-essential data files.
        /// </summary>
        /// <value>The full path of the directory.</value>
        /// <remarks>
        /// Uses the <c>XDG_CACHE_HOME</c> environment variable if set and
        /// non-empty or <c>$HOME/.cache</c> otherwise.
        /// </remarks>
        public static string CacheHome {
            get {
                var dir = Environment.GetEnvironmentVariable ("XDG_CACHE_HOME");
                if (string.IsNullOrWhiteSpace (dir)) {
                    dir = Path.Combine (
                        Environment.GetFolderPath (Environment.SpecialFolder.UserProfile),
                        ".cache");
                }
                return dir;
            }
        }

        public static string RuntimeDir {
            get {
                var dir = Environment.GetEnvironmentVariable ("XDG_RUNTIME_DIR");
                // TODO: need to figure out default directory.
                return dir;
            }
        }

        /// <summary>
        /// Searches for the file specified by <paramref name="relativePath"/>
        /// in <see cref="DataHome"/> and <see cref="DataDirs"/>.
        /// </summary>
        /// <returns>The absolute path if the file exists or <c>null</c> otherwise.</returns>
        /// <param name="relativePath">The path of the file relative to the base data directory.</param>
        public static string FindDataFile (string relativePath)
        {
            foreach (var dir in new [] { DataHome }.Union (DataDirs)) {
                var path = Path.Combine (dir, relativePath);
                if (File.Exists (path)) {
                    return Path.GetFullPath (path);
                }
            }
            return null;
        }

        /// <summary>
        /// Searches for the file specified by <paramref name="relativePath"/>
        /// in <see cref="ConfigHome"/> and <see cref="ConfigDirs"/>.
        /// </summary>
        /// <returns>The absolute path if the file exists or <c>null</c> otherwise.</returns>
        /// <param name="relativePath">The path of the file relative to the base data directory.</param>
        public static string FindConfigFile (string relativePath)
        {
            foreach (var dir in new [] { ConfigHome }.Union (ConfigDirs)) {
                var path = Path.Combine (dir, relativePath);
                if (File.Exists (path)) {
                    return Path.GetFullPath (path);
                }
            }
            return null;
        }
    }
}
