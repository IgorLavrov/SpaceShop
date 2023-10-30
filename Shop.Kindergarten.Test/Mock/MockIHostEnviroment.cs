
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Kindergarten.Test.Mock
{


    internal class MockIHostEnviroment : IHostEnvironment
    {
        string IHostEnvironment.EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IHostEnvironment.ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IHostEnvironment.ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IFileProvider IHostEnvironment.ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}
