﻿using System;
namespace OnlineStoreWorker.Settings
{
    public class OnlineStoreMqSettings
    {
        public string ExchangeName { get; set; }
        public string ExchhangeType { get; set; }
        public string QueueName { get; set; }
        public string RouteKey { get; set; }
    }
}
