using UnityEngine;

public abstract class OnMessage<T> : MonoBehaviour
{
    protected virtual void OnEnable() => Message.Subscribe<T>(Execute, this);
    protected virtual void OnDisable() => Message.Unsubscribe(this);

    protected abstract void Execute(T msg);
}

public abstract class OnMessage<T1, T2> : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        Message.Subscribe<T1>(Execute, this);
        Message.Subscribe<T2>(Execute, this);
    }

    protected virtual void OnDisable() => Message.Unsubscribe(this);

    protected abstract void Execute(T1 msg);
    protected abstract void Execute(T2 msg);
}

public abstract class OnMessage<T1, T2, T3> : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        Message.Subscribe<T1>(Execute, this);
        Message.Subscribe<T2>(Execute, this);
        Message.Subscribe<T3>(Execute, this);
    }

    protected virtual void OnDisable() => Message.Unsubscribe(this);

    protected abstract void Execute(T1 msg);
    protected abstract void Execute(T2 msg);
    protected abstract void Execute(T3 msg);
}

public abstract class OnMessage<T1, T2, T3, T4> : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        Message.Subscribe<T1>(Execute, this);
        Message.Subscribe<T2>(Execute, this);
        Message.Subscribe<T3>(Execute, this);
        Message.Subscribe<T4>(Execute, this);
    }

    protected virtual void OnDisable() => Message.Unsubscribe(this);

    protected abstract void Execute(T1 msg);
    protected abstract void Execute(T2 msg);
    protected abstract void Execute(T3 msg);
    protected abstract void Execute(T4 msg);
}

public abstract class OnMessage<T1, T2, T3, T4, T5> : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        Message.Subscribe<T1>(Execute, this);
        Message.Subscribe<T2>(Execute, this);
        Message.Subscribe<T3>(Execute, this);
        Message.Subscribe<T4>(Execute, this);
        Message.Subscribe<T5>(Execute, this);
    }

    protected virtual void OnDisable() => Message.Unsubscribe(this);

    protected abstract void Execute(T1 msg);
    protected abstract void Execute(T2 msg);
    protected abstract void Execute(T3 msg);
    protected abstract void Execute(T4 msg);
    protected abstract void Execute(T5 msg);
}
