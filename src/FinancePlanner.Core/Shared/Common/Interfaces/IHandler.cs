using FinancePlanner.Core.Shared.Common.Models;
using FinancePlanner.Core.WageCalculators;

namespace FinancePlanner.Core.Shared.Common.Interfaces;

public interface IHandler
{
    HandlerResult Handle(decimal salary);
}