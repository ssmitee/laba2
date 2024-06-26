using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public interface IPair
    {
        IPair Add(IPair other);
        IPair Subtract(IPair other);
        IPair Multiply(IPair other);
        IPair Divide(IPair other);
        string ToString();
    }

}
