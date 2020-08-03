using System;
using System.Collections.Generic;
using System.Reactive;
using DynamicData;

namespace SocialQ
{
    public interface IStoreService
    {
        IObservableCache<StoreDto, Guid> Stores { get; }

        IObservable<StoreDto> GetStore(Guid id, bool forceUpdate = true);

        IObservable<IEnumerable<StoreDto>> GetStores(bool forceUpdate = true);
    }
}