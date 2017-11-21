using Wpf.Infra;

namespace Wpf.ModuleA
{
    public class ContentViewModel : IContentViewModel
    {
        public IView View { get; set; }
        public string Message { get; set; }

        public ContentViewModel(IContentView view)
        {
            View = view;
            View.ViewModel = this;
        }
    }
}
