﻿using System.Collections.Generic;
using System.IO;

namespace Tools
{
    using Extensions;
    using Tools.Exceptions;
    using Tools.Extensions.IO;

    public static class IOHelper
    {
        /// <summary>
        /// Returns directory info for each level in the directory.
        /// Will return objects if the directory does not exist.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Stack<DirectoryInfo> GetDirectoryStack(string dir)
        {
            Guard.ThrowIfInvalidArgs(dir.IsValidPath(), "directory not valid");

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();

            while (dirInfo != null)
            {
                stack.Push(dirInfo);
                dirInfo = dirInfo?.Parent;
            }

            return stack;
        }

        public static string[] GetFiles(string path, string pattern = "*")
        {
            Guard.ThrowIfInvalidArgs(path.IsValidPath(), $"Invalid path \"{path}\"");

            return Directory.GetFiles(Path.GetDirectoryName(path), pattern);
        }
    }
}