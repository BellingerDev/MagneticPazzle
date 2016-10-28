using UnityEngine;


public class CheckpointIndicatorController : MonoBehaviour 
{
	[SerializeField]
	private TextMesh idText;

	[SerializeField]
	private string idTextFormat;

	[SerializeField]
	private TextMesh isAchievedText;

	[SerializeField]
	private string isAchievedTextFormat;

	[SerializeField]
	private TextMesh collectedElementsCountText;

	[SerializeField]
	private string collectedElementsCountTextFormat;

	private CheckpointController checkpoint;


	private void OnEnable()
	{
		checkpoint = GetComponentInParent<CheckpointController> ();
	}

	private void OnDisable()
	{
		checkpoint = null;
	}

	private void FixedUpdate()
	{
		idText.text = string.Format (idTextFormat, checkpoint.Id);
		isAchievedText.text = string.Format (isAchievedTextFormat, checkpoint.IsAchieved);
		collectedElementsCountText.text = string.Format (collectedElementsCountTextFormat, checkpoint.CollectedElementsCount);
	}
}
