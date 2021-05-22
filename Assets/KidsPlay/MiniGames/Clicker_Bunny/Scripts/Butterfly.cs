using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : Insect
{
	ButtefliesCounter _buttefliesCounter;

	bool _isClick = false;

	public override void Spawn(Rect rect, ButtefliesCounter buttefliesCounter, int side)
	{
		base.Spawn(rect, buttefliesCounter, side);

		_buttefliesCounter = buttefliesCounter;
	}

	public override void ClickOnMe()
	{
		if (!_isClick)
		{
			_isClick = true;

			Destruction(0);

			_buttefliesCounter.IncreaseCounterByOne();
		}
	}
}
