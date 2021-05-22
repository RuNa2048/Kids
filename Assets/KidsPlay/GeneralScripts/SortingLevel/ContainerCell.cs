using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class ContainerCell : MonoBehaviour
{
	[SerializeField]
	protected string nameField;
	public string Name { get { return nameField; } }

	[Header("Moving")]
	[SerializeField]
	private float _cellSpeed;

	protected Image imageField;
	protected RectTransform rectTransform;
	public RectTransform GetRectTransform() => rectTransform;

	protected float rendererTime;

	private void Awake()
	{
		imageField = GetComponent<Image>();
		rectTransform = GetComponent<RectTransform>();
	}

	public abstract void Renderer(IDoubleItem item);

	public abstract void Move(Vector2 point);

	protected IEnumerator MoveTo(Vector2 position)
	{
		float step = _cellSpeed * Time.deltaTime;

		while ((Vector2)rectTransform.position != position)
		{
			rectTransform.position = Vector2.MoveTowards(rectTransform.position, position, step);

			yield return null;
		}
	}
}
