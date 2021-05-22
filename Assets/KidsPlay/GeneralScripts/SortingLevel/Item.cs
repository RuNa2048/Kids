using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
	public int Id => id;
	public Sprite UIMainIcon => mainIcon;

	[SerializeField]
	protected int id;
	[SerializeField]
	protected Sprite mainIcon;
}
