# Padrão Decorator

O **padrão Decorator** é um padrão de design estrutural que permite adicionar funcionalidade a um objeto de forma dinâmica, sem modificar o código da classe original ou criar subclasses adicionais. Esse padrão é muito útil quando você deseja combinar comportamentos de maneira flexível.

---

## Como funciona o padrão Decorator?

1. **Componente Base**: Uma interface ou classe abstrata que define o contrato (os métodos que serão implementados).
2. **Componente Concreto**: Uma classe que implementa o componente base e contém a lógica padrão.
3. **Decorador Base**: Uma classe abstrata que implementa o componente base e aceita um componente em seu construtor. Ela delega as chamadas para o componente recebido.
4. **Decoradores Concretos**: Classes específicas que estendem o decorador base e adicionam funcionalidades antes ou depois de delegar as chamadas ao componente envolvido.

---

## Exemplo Prático

Vamos criar um exemplo para um sistema de envio de mensagens onde você pode adicionar funcionalidades, como criptografia e compressão, utilizando o padrão Decorator.

### 1. Componente Base
```csharp
public interface IMessage
{
    string GetContent();
}
```

### 2. Componente Concreto
```csharp
public class TextMessage : IMessage
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
```

### 3. Decorador Base
```csharp
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
```

### 4. Decoradores Concretos

**Criptografia**
```csharp
public class EncryptedMessage : MessageDecorator
{
    public EncryptedMessage(IMessage message) : base(message) { }

    public override string GetContent()
    {
        string content = _message.GetContent();
        return $"Encrypted({content})"; // Simulação de criptografia
    }
}
```

**Compressão**
```csharp
public class CompressedMessage : MessageDecorator
{
    public CompressedMessage(IMessage message) : base(message) { }

    public override string GetContent()
    {
        string content = _message.GetContent();
        return $"Compressed({content})"; // Simulação de compressão
    }
}
```

### 5. Utilização
```csharp
class Program
{
    static void Main()
    {
        IMessage message = new TextMessage("Hello, World!");
        Console.WriteLine("Original: " + message.GetContent());

        // Adicionando criptografia
        message = new EncryptedMessage(message);
        Console.WriteLine("Encrypted: " + message.GetContent());

        // Adicionando compressão
        message = new CompressedMessage(message);
        Console.WriteLine("Compressed & Encrypted: " + message.GetContent());
    }
}
```

---

## Saída do programa
```
Original: Hello, World!
Encrypted: Encrypted(Hello, World!)
Compressed & Encrypted: Compressed(Encrypted(Hello, World!))
```

---

## Benefícios do Padrão Decorator

- **Flexibilidade**: Permite adicionar comportamentos sem alterar o código existente.
- **Composição Dinâmica**: Você pode combinar decoradores de várias formas para criar funcionalidades complexas.

## Considerações

- O código pode ficar mais complexo, especialmente com muitas camadas de decoradores.
- Pode aumentar o uso de memória devido à criação de objetos adicionais.
