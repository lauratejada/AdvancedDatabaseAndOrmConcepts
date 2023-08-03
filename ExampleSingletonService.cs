using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDI.Example
{
    internal sealed class ExampleSingletonService : IExampleSingletonService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
