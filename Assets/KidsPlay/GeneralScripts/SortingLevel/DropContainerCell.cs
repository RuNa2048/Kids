using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropContainerCell : ContainerCell
{
	public Rect CellRect { get { return rectTransform.rect; } }

	public override void Renderer(IDoubleItem item)
	{
		nameField = item.Name;
		if(item.UIEmptyIcon)
			imageField.sprite = item.UIEmptyIcon;

		imageField.raycastTarget = false;
	}

	public override void Move(Vector2 point)
	{
		
	}
}
