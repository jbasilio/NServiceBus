using System;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.ObjectBuilder;

namespace NServiceBus.Host.Tests
{
    public class ServerEndpointConfig : IConfigureThisEndpoint,
                                        As.aPublisher  
    {
    }

    public class ServerEndpointConfigWithCustomSagaPersister : IConfigureThisEndpoint,
                                    As.aServer,
                                    ISpecify.MyOwnSagaPersistence
    {
        public void Init(Configure configure)
        {
            configure.Configurer.ConfigureComponent<FakePersister>(ComponentCallModelEnum.Singleton);
        }
    }

    
    public class ServerEndpointConfigWithCustomConfigSource : IConfigureThisEndpoint,
                                        As.aPublisher,
                                        ISpecify.MyOwnConfigurationSource
  
    {
        public static IConfigurationSource ConfigurationSource { get; set; }
        public IConfigurationSource Source
        {
            get { return ConfigurationSource; }
        }
    }
     

    public class FakePersister
    {
    }
}