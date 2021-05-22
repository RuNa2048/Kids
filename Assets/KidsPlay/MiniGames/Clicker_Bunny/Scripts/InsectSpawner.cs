using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private ButtefliesCounter _buttefliesCounter;
	[SerializeField] private CheckPointOccurrence _pointChecker;

	[Header("Pull objects")]
	[SerializeField] private List<Insect> _butteflyPrefabs;
	[SerializeField] private List<Insect> _birdPrefabs;
	[SerializeField] private List<Insect> _beePrefabs;
	[SerializeField] private List<Insect> _ladybugsPrefabs;

	[Header("Spawning Settings")]
	[SerializeField] private int _maxAmountBirdsPerWave = 2;
	[SerializeField] private int _maxAmountBeesPerWave = 3;
	[SerializeField] private int _maxAmountLadybugsPerWave = 2;

	List<Insect> _insectsInCurrentWave;

	RectTransform _rectTransform;

	int _currentWave = 0;

	public void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		SpawningWave();
	}

	public void SpawningWave()
	{
		List<Insect> waveInsects = new List<Insect>();
		_insectsInCurrentWave = new List<Insect>();

		waveInsects.Add(_butteflyPrefabs[_currentWave]);

		for (int i = 0; i < _maxAmountBeesPerWave; i++)
		{
			int rndIndex = Random.Range(0, _beePrefabs.Count - 1);

			waveInsects.Add(_beePrefabs[rndIndex]);
		}

		for (int i = 0; i < _maxAmountBirdsPerWave; i++)
		{
			int rndIndex = Random.Range(0, _birdPrefabs.Count - 1);

			waveInsects.Add(_birdPrefabs[rndIndex]);
		}

		for (int i = 0; i < _maxAmountLadybugsPerWave; i++)
		{
			int rndIndex = Random.Range(0, _ladybugsPrefabs.Count - 1);

			waveInsects.Add(_ladybugsPrefabs[rndIndex]);
		}

		int numberOfUnselectedSides = waveInsects.Count;
		int numberOfUnselectedLeftSide = numberOfUnselectedSides / 2;
		int numberOfUnselectedRightSide = numberOfUnselectedSides - numberOfUnselectedLeftSide;

		int numberOfSelectedRightSide = 0;
		int	numberOfSelectedLeftSide = 0;

		foreach (Insect insect in waveInsects)
		{
			Insect ins = Instantiate(insect, _rectTransform, false);

			int rndIndex = 0;

			while (rndIndex == 0)
			{
				rndIndex = Random.Range(-1, 2);
			}

			if ((rndIndex == -1 && numberOfSelectedLeftSide < numberOfUnselectedLeftSide) || numberOfSelectedRightSide >= numberOfUnselectedRightSide)
			{
				numberOfSelectedLeftSide++;
				rndIndex = -1;
			}
			else if((rndIndex == 1 && numberOfSelectedRightSide < numberOfUnselectedRightSide) || numberOfSelectedLeftSide >= numberOfUnselectedLeftSide)
			{
				numberOfSelectedRightSide++;
				rndIndex = 1;
			}

			ins.Spawn(_rectTransform.rect, _buttefliesCounter, rndIndex);

			_insectsInCurrentWave.Add(ins);
		}

		foreach (Insect insect in _insectsInCurrentWave)
		{

		}

		_currentWave++;
	}

	public void CleainingWave(bool isSpawnNewWave)
	{
		StartCoroutine(AllInsectsDestruction(isSpawnNewWave));
	}

	private IEnumerator AllInsectsDestruction(bool isSpawnNewWave)
	{
		yield return new WaitForSeconds(2f);

		float destructionDelay = 3f;

		for (int i = 1; i < _insectsInCurrentWave.Count; i++)
		{
			_insectsInCurrentWave[i].Destruction(destructionDelay);
			destructionDelay *= 0.5f;
		}

		if (isSpawnNewWave)
		{
			yield return new WaitForSeconds(2f);

			SpawningWave();
		}
	}
}
