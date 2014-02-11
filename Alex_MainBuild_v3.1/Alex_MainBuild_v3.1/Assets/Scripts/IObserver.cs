using UnityEngine;
using System.Collections;

public interface IObserver  
{
    void ObserverUpdate(object sender, object message);
}
