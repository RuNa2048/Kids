using UnityEngine;

public class TrainingPanel: MonoBehaviour
{
	[SerializeField]
	private LevelManager _levelManager;

	private void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				_levelManager.ChangeTimeline();
				this.enabled = false;
			}
		}
	}
}
