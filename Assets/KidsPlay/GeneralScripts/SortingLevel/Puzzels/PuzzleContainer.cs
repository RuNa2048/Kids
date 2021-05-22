using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleContainer : MonoBehaviour
{
	[SerializeField]
	private int _quantityCellSwaps;
	[SerializeField]
	List<PuzzleCell> _cells;
	public int CellsCount() => _cells.Count;

	public void SwapCells()
	{
		List<Vector3> pullCellsPosition = new List<Vector3>();
		List<Vector3> randomizedPullCellsPosition = new List<Vector3>();

		foreach (PuzzleCell cell in _cells)
		{
			pullCellsPosition.Add(cell.transform.position);
		}

		int quantityCells = pullCellsPosition.Count;

		for (int i = 0; i < quantityCells; i++)
		{
			int randomIndex = Random.Range(0, pullCellsPosition.Count);
			randomizedPullCellsPosition.Add(pullCellsPosition[randomIndex]);
			pullCellsPosition.RemoveAt(randomIndex);
		}

		for (int i = 0; i < _cells.Count; i++)
		{
			_cells[i].Init(randomizedPullCellsPosition[i]);
		}
	}
}