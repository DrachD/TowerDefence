using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    private float originalScaleX;
    private void Start()
    {
        originalScaleX = gameObject.transform.localScale.x;
    }
    private void Update()
    {
        Vector3 tempScale = gameObject.transform.localScale;
        tempScale.x = currentHealth / maxHealth * originalScaleX;
        gameObject.transform.localScale = tempScale;
    }
}
