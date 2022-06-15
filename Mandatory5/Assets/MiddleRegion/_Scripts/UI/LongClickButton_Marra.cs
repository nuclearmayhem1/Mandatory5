using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton_Marra : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	public bool IsC;

	public Camera Cam1, Cam2;
	private float pointerDownTimer;

	[SerializeField]
	private GameObject C;

	[SerializeField]
	private float requiredHoldTime;

	public UnityEvent onLongClick;

	[SerializeField]
	private Image fillImage;

	[SerializeField] private CanvasGroup MovementControls;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Debug.Log("OnPointerDown");
		Disappear();
	}

   public void Disappear(){
		//GetComponent<Image>().color = new color (1,1,1,1,);
		//GetComponent<Image>().color = new Color(1, 1, 1, 0);
		//GetComponent<Button>().enabled = false;
		if (!IsC)
        {
			transform.parent.transform.parent.GetComponent<CanvasGroup>().alpha = 0;
			transform.parent.transform.parent.GetComponent<CanvasGroup>().interactable = false;
			transform.parent.transform.parent.GetComponent<CanvasGroup>().blocksRaycasts = false;
			if (MovementControls)
			{
				MovementControls.interactable = true;
				MovementControls.alpha = 1;
			}
        }
		
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		Debug.Log("OnPointerUp");
	}

	private void Update()
	{
		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				IsC = false;
				Disappear();
				if (onLongClick != null)
					onLongClick.Invoke();

				Cam1.gameObject.SetActive(false);
				Cam2.gameObject.SetActive(true);

				C.SetActive(true);
				Reset();
			}
			if (fillImage) {
				fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
				}
		}
	}

	private void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
		if (fillImage)
			fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
	}

}