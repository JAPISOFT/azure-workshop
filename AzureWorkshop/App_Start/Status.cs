﻿using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using AzureWorkshop.Models;
using AzureWorkshop.Repositories.Interfaces;
using AzureWorkshop.Services.Interfaces;
using Microsoft.ApplicationInsights.Extensibility;
using Ninject;

namespace AzureWorkshop
{
    public static class Hub
    {
        public static void Notify(string breakpoint)
        {
            string teamName = ConfigurationManager.AppSettings["TeamName"];

            using (WebClient webClient = new WebClient())
            {
                Url url = new Url("https://www.miroslavholec.cz/workshops/barcamp/add");

                StringBuilder sb = new StringBuilder();
                sb.Append("?tm=" + (teamName ?? Environment.MachineName));
                sb.Append("&bp=" + breakpoint);

                try
                {
                    webClient.DownloadString("https://www.miroslavholec.cz/workshops/barcamp/add" + sb.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void Notify(IKernel kernel)
        {
            var repository = kernel.Get<IExchangesRepository>(); 
            var service = kernel.Get<IExchangeService>();
            var context = kernel.Get<AppContext>();

            bool sqlWorks = false;
            try
            {
                if (repository.GetType().Name.Contains("Sql"))
                {
                    try
                    {
                        var test = context.Exchanges.FirstOrDefault();
                        sqlWorks = true;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
            }

            string teamName = ConfigurationManager.AppSettings["TeamName"];

            using (WebClient webClient = new WebClient())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?rep=" + repository.GetType().Name);
                sb.Append("&svc=" + service.GetType().Name);
                sb.Append("&tm=" + (teamName ?? Environment.MachineName));
                sb.Append("&ai=" + TelemetryConfiguration.Active.InstrumentationKey);
                sb.Append("&sql=" + sqlWorks);

                try
                {
                    webClient.DownloadString("https://www.miroslavholec.cz/workshops/barcamp/add" + sb.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); 
                }
            }
        }
    }
}