using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collection : IEnumerable {
    public abstract IEnumerator GetEnumerator();
}

public abstract class Iterator : IEnumerator {
    object IEnumerator.Current => Current();

    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();
}