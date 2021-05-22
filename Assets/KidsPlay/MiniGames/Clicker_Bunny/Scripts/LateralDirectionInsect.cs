using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralDirectionInsect : Insect
{
	public override void CheckMovingDirection()
	{
		if (rectTransform.anchoredPosition.x > rndPos.x)
		{
			rectTransform.localScale = Vector3.one;
		}
		else if (rectTransform.anchoredPosition.x < rndPos.x)
		{
			rectTransform.localScale = new Vector3(-1, 1, 1);
		}
	}
}
