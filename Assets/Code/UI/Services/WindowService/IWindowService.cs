using Code.Services;
using Code.UI.Windows;

namespace Code.UI.Services.WindowService
{
    public interface IWindowService : IService
    {
        WindowBase Open(WindowType type);
    }
}