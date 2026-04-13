using UnityEngine;
using TMPro;

public class FloatingScore : MonoBehaviour
{
    private float floatSpeed = 1.5f;

    public void Setup(int scoreValue)
    {
        TextMeshPro textComponent = GetComponent<TextMeshPro>();
        if (textComponent != null) 
        {
            textComponent.text = "+" + scoreValue;
            
            // AUTOMATIC COLOR CODING
            if (scoreValue <= 10) 
                textComponent.color = Color.cyan; // Basic
            else if (scoreValue <= 20) 
                textComponent.color = new Color(1f, 0.5f, 0f); // Orange for Double
            else 
                textComponent.color = Color.yellow; // Gold for Epic
        }
        
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
        
        if (Camera.main != null)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0); 
        }
    }
}