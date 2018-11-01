using System;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Xamarin.Aspects.Contracts.Framework
{
    [PSerializable]

    public sealed class MethodGuard : MethodInterceptionAspect
    {
        private BaseCommandContract _commandContract;

        public MethodGuard()
        {
        }

        public MethodGuard(Type commandContractType)
        {
            _commandContract = (BaseCommandContract)Activator.CreateInstance(commandContractType);
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            try
            {
                if (_commandContract.PreCondition())
                {
                    _commandContract.PreConditionAsync().ContinueWith(task =>
                    {
                        if (task.Result)
                            args.Proceed();
                        else
                        {
                            args.ReturnValue = false;

                        }
                    });
                }
                else
                {
                    args.ReturnValue = false;

                }
            }
            catch (Exception e)
            {
                args.ReturnValue = false;

            }
        }
    }
}