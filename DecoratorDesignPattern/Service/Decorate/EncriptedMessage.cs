using DecoratorDesignPattern.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.Service.Decorate
{
    /// <summary>
    /// 4. Decoradores Concretos
    /// </summary>
    public class EncryptedMessage : MessageDecorator
    {
        public EncryptedMessage(IMessage message) : base(message) { }

        public override string GetContent()
        {
            string content = _message.GetContent();
            return $"Encrypted({content})"; // Simulação de criptografia
        }
    }

}
