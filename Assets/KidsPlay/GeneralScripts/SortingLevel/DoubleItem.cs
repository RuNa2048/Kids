using UnityEngine;

[CreateAssetMenu(menuName = "Item/DoubleItem")]
public class DoubleItem :ScriptableObject, IDoubleItem
{
	public string Name => _name;
	public Sprite UIMainIcon => _mainIcon;
	public Sprite UIEmptyIcon => _emptyIcon;

	[SerializeField]
	private string _name;
	[SerializeField]
	private Sprite _mainIcon;
	[SerializeField]
	private Sprite _emptyIcon;
}
