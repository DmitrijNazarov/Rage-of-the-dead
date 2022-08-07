using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

	[SerializeField] float maxValue = 100;
	[SerializeField] Color color = Color.red;
	[SerializeField] int width = 4;
	[SerializeField] Slider slider;
	[SerializeField] bool isRight;

	private static float current;

	void Start()
	{
		slider.fillRect.GetComponent<Image>().color = color;

		slider.maxValue = maxValue;
		slider.minValue = 0;
		current = maxValue;

		UpdateUI();
	}

	public static void DecreaseCurrentValue(float decrease)
    {
		current -= decrease;
	}

	public static float currentValue
	{
		get { return current; }
	}

	void Update()
	{
		if (current <= 0)
		{
			SceneManager.LoadScene("Background Example 2");
		}
		if (current > maxValue) current = maxValue;
		slider.value = current;
	}

    private void FixedUpdate()
    {
		AdjustCurrentValue(-0.0935f);
    }

    void UpdateUI()
	{
		RectTransform rect = slider.GetComponent<RectTransform>();

		int rectDeltaX = Screen.width / width;
		float rectPosX = 0;

		if (isRight)
		{
			rectPosX = rect.position.x - (rectDeltaX - rect.sizeDelta.x) / 2;
			slider.direction = Slider.Direction.RightToLeft;
		}
		else
		{
			rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
			slider.direction = Slider.Direction.LeftToRight;
		}

		rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
		rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
	}

	public static void AdjustCurrentValue(float adjust)
	{
		current += adjust;
		
	}
}
