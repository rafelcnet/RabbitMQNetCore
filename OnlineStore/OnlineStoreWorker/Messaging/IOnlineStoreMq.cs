using System;
namespace OnlineStoreWorker.Messaging
{
    public interface IOnlineStoreMq
    {
        void ConsumeMessage();
    }
}
