using System;
using System.Web.Hosting;

namespace LibraryWeb.Services
{
    public class PathProvider : IPathProvider
    {
        private const string oldPath = "\\bin\\Debug";
        public string FilePath(string file)
        {
            return HostingEnvironment.IsHosted ? HostingEnvironment.MapPath(file) : AppDomain.CurrentDomain.BaseDirectory.Replace(oldPath, file);
        }
    }
}