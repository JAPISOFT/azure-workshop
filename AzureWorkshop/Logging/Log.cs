using System;
using Microsoft.ApplicationInsights;

namespace AzureWorkshop.Logging
{
    public static class Log
    {
        public static void Event(string message)
        {
            TelemetryClient tc = new TelemetryClient();
            tc.TrackEvent(message);
        }

        public static void Error(Exception exception)
        {
            TelemetryClient tc = new TelemetryClient();
            tc.TrackException(exception);
        }

        public static void Metric(string name, double time)
        {
            TelemetryClient tc = new TelemetryClient();
            tc.TrackMetric(name, time);
        }
    }
}