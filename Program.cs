using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

using AdminConsole.Models;

namespace AdminConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminRuns.RunAsync().GetAwaiter().GetResult();
        }
    }
}
