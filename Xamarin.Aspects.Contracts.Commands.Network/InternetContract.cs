using Plugin.Connectivity;
using PostSharp.Aspects;
using PostSharp.Serialization;
using Xamarin.Aspects.Contracts.Framework;

namespace Xamarin.Aspects.Contracts.Commands.Network
{
    [PSerializable]
    public sealed class InternetContract : BaseCommandContract
    {
        public InternetContract()
        {
            CrossConnectivity.Current.ConnectivityChanged += this.FireContractChanged;
        }
        public override bool PreCondition()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}