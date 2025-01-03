using DecoratorDesignPattern.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.Service.Implementation
{
    /// <summary>
    /// 2. Componente Concreto
    /// </summary>
    internal class TextMessage : IMessage
    {
        private readonly string _content;

        public TextMessage(string content)
        {
            _content = content;
        }

        public string GetContent()
        {
            return _content;
        }
    }
}
