using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Serialization;
using PostSharp.Reflection;
using PostSharp.Serialization;

namespace Xamarin.Aspects.Contracts.Framework
{
    [PSerializable]
    [AspectConfiguration(SerializerType = typeof(MsilAspectSerializer))]
    public sealed class CommandContract :
        InstanceLevelAspect, IAspectProvider
    {
        private ICommand _instance;
        private BaseCommandContract _commandContract;
        private Type _commandContractType;

        public CommandContract(Type commandContractType)
        {
            _commandContractType = commandContractType;
            _commandContract =(BaseCommandContract) Activator.CreateInstance(commandContractType);
        }

        public override object CreateInstance(AdviceArgs adviceArgs)
        {

            this._instance = adviceArgs.Instance as ICommand;
            _commandContract.ContractChanged += (s, e) =>
            {
                OnCanExecuteChanged();
            };
            return base.CreateInstance(adviceArgs);
        }

        public override bool CompileTimeValidate(Type type)
        {
            return typeof(ICommand).IsAssignableFrom(type);
        }


        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var type = (Type)targetElement;

            return type.GetMethods()
                .Where(x => x.Name == "CanExecute").Select(
                    m => new AspectInstance(m,
                        new MethodGuard(_commandContractType),
                        new AspectConfiguration()
                        {
                            AspectPriority = this.AspectPriority
                        }));
        }


        [IntroduceMember(Visibility = Visibility.Family,
            IsVirtual = true, OverrideAction = MemberOverrideAction.Ignore)]
        public void OnCanExecuteChanged()
        {
            FieldInfo info = _instance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(EventHandler));

            if (info != null)
            {
                var evHandler =
                    info.GetValue(_instance) as EventHandler;
                if (evHandler != null)
                    evHandler.Invoke(_instance.GetType(),
                        EventArgs.Empty);
            }
        }

    
    }
}