using gamedevproject.Interfaces;
using System;
using System.IO;

namespace gamedevproject.ScreenClasses
{
    internal class StartScreen : IScreen
    {
        private IServiceProvider services;
        private Stream fileStream;
        private int v;

        public StartScreen(IServiceProvider services, Stream fileStream, int v)
        {
            this.services = services;
            this.fileStream = fileStream;
            this.v = v;
        }
    }
}
