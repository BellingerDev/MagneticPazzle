using System;
using System.Collections.Generic;


namespace Utils.Events
{
	public static class EventManager
	{
		private static Dictionary<Enum, Dictionary<Enum, Action<object>>> collection = 
			new Dictionary<Enum, Dictionary<Enum, Action<object>>>();


		public static void Subscribe(Enum category, Enum type, Action<object> callback)
		{
			if (collection.ContainsKey(category))
			{
				if (collection[category].ContainsKey(type))
					collection[category][type] += callback;
				else
					collection[category].Add(type, callback);
			}
			else
			{
				collection.Add(category, new Dictionary<Enum, Action<object>>());
				collection[category].Add(type, callback);
			}
		}

		public static void Unsubscribe(Enum category, Enum type, Action<object> callback)
		{
			if (collection.ContainsKey(category))
				if (collection[category].ContainsKey(type))
					collection[category][type] -= callback;
		}

		public static void Send(Enum category, Enum type, object data)
		{
			if (collection.ContainsKey(category))
				if (collection[category].ContainsKey(type))
					collection[category][type](data);
		}
	}
}