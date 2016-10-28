using System;
using System.Collections.Generic;


public static class EventManager
{
	private static Dictionary<Enum, Action<object>> _events
		 = new Dictionary<Enum, Action<object>>();

	
	public static void Send(Enum ev, object param)
	{
		if (_events.ContainsKey(ev))
			_events[ev](param);
	}
	
	public static void Subscribe(Enum ev, Action<object> callback)
	{
		if (_events.ContainsKey(ev))
			_events[ev] += callback;
		else
		{
			_events.Add(ev, null);
			_events[ev] += callback;
		}
	}
	
	public static void Unsubscribe(Enum ev, Action<object> callback)
	{
		if (_events.ContainsKey(ev))
			_events[ev] -= callback;
	}
}
