using UnityEngine;
using UnityEngine.Events;

public static class EventSystem
{
    public static CustomEvent custom = new CustomEvent();
    public class CustomEvent
    {
        public UnityAction testEvent;
    }
}
