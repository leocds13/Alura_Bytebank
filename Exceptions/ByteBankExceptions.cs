using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_atendimento.Exceptions
{
  [System.Serializable]
  public class ByteBankException : System.Exception
  {
    public ByteBankException() { }
    public ByteBankException(string message) : base("Exception of ByteBank => " + message) { }
    public ByteBankException(string message, System.Exception inner) : base(message, inner) { }
    protected ByteBankException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }
}