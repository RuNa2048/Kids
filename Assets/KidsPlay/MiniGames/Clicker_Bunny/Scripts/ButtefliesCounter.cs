using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtefliesCounter : MonoBehaviour
{
	[SerializeField] private InsectSpawner _insectSpawner;
	[SerializeField] private ClickerTimeline _clickerTimeline;

	[SerializeField] private TextMeshProUGUI _counter;

	int _numOfFound = 0;
	int _maxFound = 5;
	bool _isGameEnd = false;

	public void IncreaseCounterByOne()
	{
		_numOfFound++;
		_counter.text = _numOfFound.ToString();

		if (_numOfFound >= _maxFound)
		{
			_insectSpawner.CleainingWave(false);

			StartCoroutine(EndingGame());

			return;
		}

		_insectSpawner.CleainingWave(true);
	}

	private IEnumerator EndingGame()
	{
		yield return new WaitForSeconds(4f);

		_clickerTimeline.PlayTimeline();
	}
}
