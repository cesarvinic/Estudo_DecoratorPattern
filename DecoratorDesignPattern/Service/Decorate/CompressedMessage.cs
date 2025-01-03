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
    public class CompressedMessage : MessageDecorator
    {
        public CompressedMessage(IMessage message) : base(message) { }

        public override string GetContent()
        {
            string content = _message.GetContent();
            return $"Compressed({content})"; // Simulação de compressão
        } 
    }
}
