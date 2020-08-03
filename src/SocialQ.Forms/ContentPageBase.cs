using System.Reactive.Disposables;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.XamForms;
using SocialQ.ViewModels;

namespace SocialQ.Forms
{
    public class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel>
        where TViewModel : ViewModelBase
    {
        protected CompositeDisposable PageDisposables { get; } = new CompositeDisposable();
    }

    public class ContentViewBase<TViewModel> : ReactiveContentView<TViewModel>
        where TViewModel : ReactiveObject
    {
        protected CompositeDisposable ViewDisposables { get; } = new CompositeDisposable();
    }

    public class ViewCellBase<TViewModel> : ReactiveViewCell<TViewModel>
        where TViewModel : ReactiveObject
    {
        protected CompositeDisposable ViewCellDisposables { get; } = new CompositeDisposable();
    }
}