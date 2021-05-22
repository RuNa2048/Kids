using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insect : MonoBehaviour
{
	[SerializeField] protected float movingSpeed;

	[SerializeField] protected float force = 10f;

	protected RectTransform rectTransform;
	protected Vector2 rndPos;
	public void RandomPos(Vector2 pos) => rndPos = pos;

	protected Rect workArea;
	protected Animator animator;
	protected Rigidbody2D rb;

	Image _image;
	BoxCollider2D _collider;
	public Bounds ColliderBounds { get { return _collider.bounds; }}
	

	protected bool isAlive = false;
	protected float movingStep;

	public virtual void Spawn(Rect rect, ButtefliesCounter buttefliesCounter, int side)
	{
		rectTransform = GetComponent<RectTransform>();
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		_image = GetComponent<Image>();
		_collider = GetComponent<BoxCollider2D>();

		workArea = rect;
		rectTransform.anchoredPosition = CreateRandomPositionInRect();
		isAlive = true;
		movingStep = Time.deltaTime * movingSpeed;
		_collider.size = new Vector2(rectTransform.rect.width * 2, rectTransform.rect.height * 2);

		float rndXPos;

		if (side == -1)
			rndXPos = rect.xMin - _image.preferredWidth;
		else
			rndXPos = rect.xMax + _image.preferredWidth;


		float rndYPos = Random.Range(rect.yMin, rect.yMax);

		rectTransform.anchoredPosition = new Vector2(rndXPos, rndYPos);

		rndPos = CreateRandomPositionInRect();

		//StartCoroutine(Moving());

		
	}

	protected Vector2 CreateRandomPositionInRect()
	{
		float rndXPos = Random.Range(workArea.xMin, workArea.xMax);
		float rndYPos = Random.Range(workArea.yMin, workArea.yMax);
		return new Vector2(rndXPos, rndYPos);
	}

	protected IEnumerator Moving()
	{
		animator.SetBool("IsMove", true);
		CheckMovingDirection();

		while (isAlive)
		{
			if (rndPos != rectTransform.anchoredPosition)
			{
				rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, rndPos, movingStep);
			}

			if (rndPos == rectTransform.anchoredPosition)
			{
				rndPos = CreateRandomPositionInRect();
				CheckMovingDirection();
			}

			yield return null;
		}
	}

	public virtual void CheckMovingDirection()
	{
		Vector3 direction = rndPos - rectTransform.anchoredPosition;
		direction.Normalize();

		rectTransform.up = direction;
	}

	public virtual void ClickOnMe()
	{
		Debug.Log("Click: " + gameObject.name);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		CheckMovingDirection();

		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	public void Destruction(float delay)
	{
		StartCoroutine(WaitingForDestruction(delay));

		animator.SetBool("IsMove", false);

		isAlive = false;
		StopCoroutine(Moving());

		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.AddForce(Vector3.up * force * 30f);
		Destroy(gameObject, 2f);
	}

	private IEnumerator WaitingForDestruction(float time)
	{
		yield return new WaitForSeconds(time);
	}
}
