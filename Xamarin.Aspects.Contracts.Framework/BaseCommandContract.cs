using System;
using System.Threading.Tasks;
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

        public virtual bool PreCondition()
        {
            return true;

        }

        public virtual Task<bool> PreConditionAsync()
        {
            return Task.FromResult(true);}

        public void FireContractChanged(object sender,EventArgs eventArgs)
        {
            ContractChanged?.Invoke(sender,eventArgs);
        }
    }
}
