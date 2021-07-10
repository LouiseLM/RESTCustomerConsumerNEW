﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestCustomerConsumer2.MenuHandler;

namespace RestCustomerConsumer2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu.MainMenu();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //   WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
    }
}
