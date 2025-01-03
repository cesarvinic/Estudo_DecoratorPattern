using DecoratorDesignPattern.Service.Decorate;
using DecoratorDesignPattern.Service.Implementation;
using DecoratorDesignPattern.Service.Interface;
using System;
using System.Text;

namespace DecoratorDesignPattern
{
    static class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Para usar o método AppendLine dentro da classe CodeBuilder, 
             * você pode implementar um design pattern de delegação (Delegate) 
             * no qual a classe CodeBuilder encapsula uma instância de StringBuilder 
             * e delega chamadas de métodos (como AppendLine) para o objeto encapsulado.
             */

            CodeBuilder objCodeBuilder = new CodeBuilder();
            objCodeBuilder.AppendLine("/*Teste decorator*/");
            objCodeBuilder.AppendLine("public class Foo");
            objCodeBuilder.AppendLine("{");
            objCodeBuilder.AppendLine("//This is an example class");
            objCodeBuilder.AppendLine("}");

            Console.WriteLine(objCodeBuilder.ToString());

            /*
             * Exemplo Prático
             * Vamos criar um exemplo para um sistema de envio de mensagens onde você pode adicionar 
             * funcionalidades, como criptografia e compressão, utilizando o padrão Decorator.
             */

            IMessage message = new TextMessage(objCodeBuilder.ToString());
            Console.WriteLine("Original: " + message.GetContent());

            // Adicionando criptografia
            message = new EncryptedMessage(message);
            Console.WriteLine("Encrypted: " + message.GetContent());

            // Adicionando compressão
            message = new CompressedMessage(message);
            Console.WriteLine("Compressed & Encrypted: " + message.GetContent());

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Exemplo Simples de como implementar um encapsulamento, onde conseguimos dar um entendimento inicial ao Decorator com Delegates.  
    /// Para um melhor entendimento, leia o arquivo README.md, presente no projeto.
    /// </summary>
    public class CodeBuilder
    {
        //Não conseguimos herdar StringBuilder, por ela ser uma classe do tipo "selada" (sealed).
        //Portanto temos que acioná-la através da injeção de dependência.
        private readonly StringBuilder _stringBuilder;

        public CodeBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public StringBuilder Append(string value) => _stringBuilder.Append(value);
        public StringBuilder AppendLine(string value) => _stringBuilder.AppendLine(value);
        public override string ToString() => _stringBuilder.ToString();
    }

}