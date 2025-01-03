using DecoratorDesignPattern.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.Service.Decorate
{
    /// <summary>
    /// 3. Decorador Base
    /// </summary>
    public abstract class MessageDecorator : IMessage
    {
        protected readonly IMessage _message;

        protected MessageDecorator(IMessage message) 
        { 
            _message = message;
        }

        public virtual string GetContent()
        { 
            return _message.GetContent();
        }
    }
}
