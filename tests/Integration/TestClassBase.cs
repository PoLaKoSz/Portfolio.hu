using System.IO;

namespace Library.Tests.Integration
{
    internal abstract class TestClassBase
    {
        private readonly string _path;
        private readonly string _module;

        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="module">Non null name of the module (subdirectory).</param>
        public TestClassBase(string module)
        {
            _module = module;
            _path = Path.Combine("StaticResources", _module);
        }
        
        /// <summary>
        /// Get the source code from a previously saved HTML file.
        /// </summary>
        protected string GetTestData(string fileName)
        {
            return File.ReadAllText(Path.Combine(_path, $"{fileName}.html"));
        }
    }
}
