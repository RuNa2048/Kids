using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCell : Cell
{
	[SerializeField]
	protected float speed;

	protected IMovable movableBehavour;

	//public void SetInitialiableBehaviour(IInitializable init) => _initializableBehavior = init;
	public void SetMovableBehaviour(IMovable init) => movableBehavour = init;

	//public void PerformInitialization(List<Item> items) => _initializableBehavior.
	public void PerformMove(Vector2 point) => StartCoroutine(movableBehavour.Move(rectTransform, point, speed));

	public override void Startup(Item item)
	{

	}
}
