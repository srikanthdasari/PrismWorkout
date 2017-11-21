using Wpf.Infra;

namespace Wpf.ModuleA
{
    public interface IContentViewModel:IViewModel
    {
        string Message { get; set; }
    }
}
