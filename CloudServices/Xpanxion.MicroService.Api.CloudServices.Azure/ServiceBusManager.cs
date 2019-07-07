using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces;

namespace Xpanxion.MicroService.Api.CloudServices.Azure
{
   public class ServiceBusManager //: IServiceBusManager
    {
        static IQueueClient queueClient;
        static ITopicClient topicClient;
        static ISubscriptionClient subscriptionClient;
        string ServiceBusConnectionString = string.Empty;
        private ManagementClient _managementClient;

        public ServiceBusManager(string connectionString)
        {
            ServiceBusConnectionString = connectionString;
            _managementClient = new ManagementClient(ServiceBusConnectionString);
        }



        public async Task CreateQueue(string queueName)
        {
            try
            {
                if (string.IsNullOrEmpty(queueName))
                {
                    throw new Exception("Queue name is empty!");
                }

                if (!await _managementClient.QueueExistsAsync(queueName).ConfigureAwait(false))
                {
                    await _managementClient.CreateQueueAsync(queueName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateTopic(string topicName)
        {
            try
            {
                if (string.IsNullOrEmpty(topicName))
                {
                    throw new Exception("Topic name is empty!");
                }

                if (!await _managementClient.TopicExistsAsync(topicName).ConfigureAwait(false))
                {
                    await _managementClient.CreateTopicAsync(topicName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateSubscription(string topicName, string subscriberName)
        {
            try
            {
                if (string.IsNullOrEmpty(subscriberName))
                {
                    throw new Exception("Subscription name is empty!");
                }
                if (string.IsNullOrEmpty(topicName))
                {
                    throw new Exception("Topic name is empty!");
                }

                if (!await _managementClient.SubscriptionExistsAsync(topicName, subscriberName).ConfigureAwait(false))
                {
                    await _managementClient.CreateSubscriptionAsync(topicName, subscriberName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

}
