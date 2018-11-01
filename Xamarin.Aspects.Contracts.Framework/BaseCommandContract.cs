using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Serialization;
using PostSharp.Serialization;

namespace Xamarin.Aspects.Contracts.Framework
{
    [PSerializable]
    [AspectConfiguration(SerializerType = typeof(MsilAspectSerializer))]
    public abstract class BaseCommandContract
    {
        public event EventHandler ContractChanged;

        public abstract bool PreCondition();

        public void FireContractChanged(object sender,EventArgs eventArgs)
        {
            ContractChanged?.Invoke(sender,eventArgs);
        }
    }
}
