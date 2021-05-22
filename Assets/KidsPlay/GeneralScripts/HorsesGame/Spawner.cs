using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private RectTransform[] _lines;
	[SerializeField]
	private RectTransform[] _spawnPoints;
	[SerializeField]
	private StageManager _stageManager;
	[SerializeField]
	private Transform _content;

	private void Awake()
	{
		_stageManager = GetComponent<StageManager>();
	}

	public void Spawn(Bunches bunches)
	{
		List<Bunch> randomizedBunches = RandomizeBunches(bunches).bunches;

		List<Horse> horses = new List<Horse>();
		List<Sleigh> sleighs = new List<Sleigh>();

		foreach (Bunch bunch in randomizedBunches)
		{
			horses.Add(bunch.Horse);
			sleighs.Add(bunch.Sleigh);
		}

		for (int i = 0; i < _lines.Length - 1; i++)
		{
			Horse horse = Instantiate(horses[i], _lines[i]);
			RectTransform startPos = _lines[i];
			Vector2 pos = startPos.localPosition;
			pos.x = 1600;
			startPos.position = pos;

			//Debug.Log(position);
			//position.x += 1500;
			horse.Init(startPos, _stageManager);

			//int randomNum = Random.Range(0, sleighs.Count - 1);
			//Sleigh sleigh = Instantiate(sleighs[randomNum], _lines[i]);
			//sleigh.RightHorse = horses[i];

			//sleigh.Init(position, _content);

			//sleighs.RemoveAt(randomNum);
		}
	}

	private Bunches RandomizeBunches(Bunches initBunches)
	{
		for (int i = initBunches.bunches.Count - 1; i >= 1; i--)
		{
			int j = Random.Range(0, initBunches.bunches.Count - 1);

			var tempCell = initBunches.bunches[j];
			initBunches.bunches[j] = initBunches.bunches[i];
			initBunches.bunches[i] = tempCell;
		}

		return initBunches;
	}
}
