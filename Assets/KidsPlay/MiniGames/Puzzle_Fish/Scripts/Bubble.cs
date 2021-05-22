using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Decoration
{
	[SerializeField]
	private float _lifeTime = 1f;

	protected override void Awake()
	{
		RectTransform = GetComponent<RectTransform>();

		Destroy(gameObject, _lifeTime);
	}

	public override void Init(float speed)
	{
		movingSpeed = speed;
	}

	protected override void Update()
	{
		RectTransform.anchoredPosition += (Vector2)transform.up * Mathf.Sin(Time.deltaTime * movingSpeed) * movingMagnitude;
	}
}
