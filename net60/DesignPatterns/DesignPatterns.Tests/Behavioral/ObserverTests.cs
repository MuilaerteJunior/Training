using Xunit;
using DesignPatterns.Behavioral.Observer;
using System;

namespace DesignPatterns.Tests.Creational
{
    public class ObserverTests {
        [Fact(DisplayName = "Test main observer concepts")]
        public void ValidateObserverDefinition(){

            var topic = new Topic();
            var sub1 = new Subscriber();            
            var sub2 = new Subscriber();
            var sub3 = new ADigitalSubscriber();
            
            topic.Register(sub1);
            topic.Register(sub2);
            topic.Register(sub3);

            Assert.Equal(topic.CurrentContent, sub1.GetInformationFromTopic());
            Assert.Equal(sub1.GetInformationFromTopic(), sub2.GetInformationFromTopic());
            Assert.Equal(sub2.GetInformationFromTopic(), sub3.GetInformationFromTopic());

            topic.DoSomething();
            
            Assert.Equal(topic.CurrentContent, sub1.GetInformationFromTopic());
            Assert.Equal(sub1.GetInformationFromTopic(), sub2.GetInformationFromTopic());
            Assert.Equal(sub2.GetInformationFromTopic(), sub3.GetInformationFromTopic());
        }

        [Fact(DisplayName = "Test observer DP for register method")]
        public void ValidateObserver_Register_Method(){

            var topic = new Topic();
            var sub1 = new Subscriber();            
            var sub2 = new Subscriber();
            var sub3 = new ADigitalSubscriber();
            
            Assert.Equal(0, topic.SubscribersCount());

            topic.Register(sub1);
            topic.Register(sub2);
            topic.Register(sub3);

            Assert.Equal(3, topic.SubscribersCount());
        }

        [Fact(DisplayName = "Test observer DP for unregister method")]
        public void ValidateObserver_Unregister_Method(){

            var topic = new Topic();
            var sub1 = new Subscriber();            
            var sub2 = new Subscriber();
            var sub3 = new ADigitalSubscriber();
            
            Assert.Equal(0, topic.SubscribersCount());

            topic.Register(sub1);
            topic.Register(sub2);
            topic.Register(sub3);

            topic.Unregister(sub2);

            Assert.Equal(2, topic.SubscribersCount());
        }
    }
}