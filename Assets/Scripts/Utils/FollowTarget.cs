using System;
using UnityEngine;


namespace Utils.CameraControllers
{
	[Serializable]
	public struct AxisSelector
	{
		[SerializeField]
		private bool x;

		[SerializeField]
		private bool y;

		[SerializeField]
		private bool z;

		public bool X { get { return x; }}
		public bool Y { get { return y; }}
		public bool Z { get { return z; }}
	}
	
	public class FollowTarget : MonoBehaviour 
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private float speed;

		[SerializeField]
		private float accuracy;

		[SerializeField]
		private bool localPositioning;

		[SerializeField]
		private AxisSelector axis;
		
		[SerializeField]
		private Vector3 _offset;

		public GameObject Target
		{
			get { return target; }
			set { target = value; }
		}

		public Vector3 Offset
		{
			get { return _offset; }
			set { _offset = value; }
		}

		public float OffsetY
		{
			get { return _offset.y; }
			set { _offset.y = value; }
		}
		
		private void Update()
		{
			ProcessPosition();
		}
		
		private void ProcessPosition()
		{
			if (target == null)
				return;
			
			Vector3 currentPosition = localPositioning ? transform.localPosition : transform.position;
			Vector3 targetPosition = localPositioning ? target.transform.localPosition : target.transform.position;
			targetPosition += _offset;
			
			if (!axis.X)
				targetPosition.x = currentPosition.x;
			
			if (!axis.Y)
				targetPosition.y = currentPosition.y;
			
			if (!axis.Z)
				targetPosition.z = currentPosition.z;

			if ((targetPosition - currentPosition).magnitude >= accuracy)
			{
				Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * speed);
				
				if (localPositioning)
					transform.localPosition = newPosition;
				else
					transform.position = newPosition;
			}
		}
	}
}