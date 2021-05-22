using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Cell : MonoBehaviour
{
	[SerializeField]
	protected int id;
	public int ID { set { id = value; } }
	[SerializeField]
	protected Image image; 

	[SerializeField]
	protected RectTransform rectTransform;
	public Vector2 ReturnPosition() => rectTransform.position;

	public abstract void Startup(Item item);
}
