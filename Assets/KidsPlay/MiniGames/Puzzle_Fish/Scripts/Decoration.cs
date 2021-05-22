using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decoration : MonoBehaviour
{
	[SerializeField]
	protected float movingMagnitude = 0.5f;

	protected float movingSpeed;

	public RectTransform RectTransform { get; set; }

	protected float currentLifeTime = 0;

	public abstract void Init(float speed);

	protected abstract void Awake();

	protected abstract void Update();
}
