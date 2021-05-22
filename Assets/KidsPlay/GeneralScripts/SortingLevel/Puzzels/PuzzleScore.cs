using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScore : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private PuzzleContainer _puzzleContainer;
	[SerializeField] private PuzzleTimeline _puzzleTimeline;
	[SerializeField] private BackgroundMusic _backgroundMusic;

	int _quantityCombinedPuzzles;
	int _numCells;

	private void Start()
	{
		_numCells = _puzzleContainer.CellsCount();
	}

	public void UpdateScore()
	{
		_quantityCombinedPuzzles++;

		if (_quantityCombinedPuzzles >= _numCells)
		{
			_backgroundMusic.ChangeMelody();
			_puzzleTimeline.CompleteGame();
		}
	}
}
