using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.Service.Interface
{
    /// <summary>
    /// 1 - COMPONENTE BASE
    /// </summary>
    public interface IMessage
    {
        string GetContent();
    }
}
