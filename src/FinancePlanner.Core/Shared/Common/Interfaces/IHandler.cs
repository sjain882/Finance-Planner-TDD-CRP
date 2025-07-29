using FinancePlanner.Core.Shared.Common.Models;

namespace FinancePlanner.Core.Shared.Common.Interfaces;

public interface IHandler
{
    HandlerResult Handle(decimal salary);
}