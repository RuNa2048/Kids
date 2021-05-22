using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragContainer : Container
{
	[Header("References: DragContainer")]
	[SerializeField]
	private ScoreManager _scoreManager;

	protected override void Awake()
	{
		base.Awake();

		_scoreManager.ChangeStageEvent += ReturnCellInStartCondition;
	}

	public void ReturnCellInStartCondition()
	{
		foreach (DragContainerCell cell in cells)
		{
			cell.EnableCell();
		}
	}

	public void DisableCell(DragContainerCell cell)
	{
		cell.StopAllCoroutines();
		cell.enabled = false;
	}
}
