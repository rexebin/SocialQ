using Akavache;
using ReactiveUI;
using Sextant;
using Shiny.Notifications;

namespace SocialQ.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IParameterViewStackService _parameterViewStackService;
        private readonly INotificationManager _notificationManager;
        private readonly IBlobCache _blobCache;

        public MainViewModel(
            IParameterViewStackService parameterViewStackService,
            INotificationManager notificationManager,
            IBlobCache blobCache)
        {
            _parameterViewStackService = parameterViewStackService;
            _notificationManager = notificationManager;
            _blobCache = blobCache;
        }
    }
}