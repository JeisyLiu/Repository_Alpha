using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// delegate for coming events
public delegate void Calling(object objpara);

// event enums
public enum E_GameCompEvent
{
    SCENE_RESET,
    GAME_START,
    GAME_END,
    GAME_PAUSE,
    GAME_RESET
}

public class EventManger : MonoBehaviour
{
    private static EventManger instanceManager;
    public static EventManger getInstance()
    {
        if (instanceManager == null)
        {
            instanceManager = new EventManger();
        }
        return instanceManager;
    }

    // Event colletor
    Dictionary<string, Calling> m_EventCollection = new Dictionary<string, Calling>();

    public void AddNewEvent(string tag, Calling caller)
    {
        if (this.m_EventCollection.ContainsKey(tag))
        {
            return;
        }
        this.m_EventCollection.Add(tag, caller);
    }

    public void RemoveEvent(string tag, Calling caller)
    {
        if (this.m_EventCollection.ContainsKey(tag))
        {
            this.m_EventCollection.Remove(tag);
        }
    }

    public void ExecuteEvent(string tag, object eventpara)
    {
        if (this.m_EventCollection.ContainsKey(tag))
        {
            this.m_EventCollection[tag](eventpara);
        }
    }
}
