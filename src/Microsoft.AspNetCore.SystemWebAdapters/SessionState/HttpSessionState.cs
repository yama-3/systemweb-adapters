// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using Microsoft.AspNetCore.SystemWebAdapters.SessionState;

namespace System.Web.SessionState;

[Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010:Generic interface should also be implemented", Justification = Constants.ApiFromAspNet)]
[Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = Constants.ApiFromAspNet)]
public class HttpSessionState : ICollection
{
    private readonly ISessionState _container;

    public HttpSessionState(ISessionState container)
    {
        _container = container;
    }

    public string SessionID => _container.SessionID;

    public int Count => _container.Count;

    public bool IsReadOnly => _container.IsReadOnly;

    public bool IsNewSession => _container.IsNewSession;

    public int Timeout
    {
        get => _container.Timeout;
        set => _container.Timeout = value;
    }

    public bool IsSynchronized => _container.IsSynchronized;

    public object SyncRoot => _container.SyncRoot;

    public void Abandon() => _container.IsAbandoned = true;

    public object? this[string name]
    {
        get => _container[name];
        set => _container[name] = value;
    }

    public void Add(string name, object value) => _container[name] = value;

    public void Remove(string name) => _container.Remove(name);

    public void RemoveAll() => _container.Clear();

    public void Clear() => _container.Clear();

    public void CopyTo(Array array, int index)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        foreach (var key in _container.Keys)
        {
            array.SetValue(_container[key], index++);
        }
    }

    public IEnumerator GetEnumerator() => _container.Keys.GetEnumerator();
}
