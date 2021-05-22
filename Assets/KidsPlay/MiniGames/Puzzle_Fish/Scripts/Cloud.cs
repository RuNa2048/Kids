using UnityEngine;

public class Cloud : Decoration
{


	protected override void Awake()
	{
		RectTransform = GetComponent<RectTransform>();
	}

	public override void Init(float speed)
	{
		movingSpeed = speed;
	}

	protected override void Update()
	{
		EscapeScreenZone();

		RectTransform.anchoredPosition += (Vector2)transform.right * movingSpeed * movingMagnitude;
	}

	private void EscapeScreenZone()
	{
		if (RectTransform.anchoredPosition.x > Screen.width / 2)
		{
			Destroy(gameObject);
		}
	}
}
