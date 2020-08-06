using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    // Serialized Fields to show damage is done to the Ship
    [SerializeField]
    GameObject prefabShip;

    [SerializeField]
    Sprite SpriteNumber01;

    [SerializeField]
    Sprite SpriteNumber02;

    [SerializeField]
    Sprite SpriteNumber03;

    const float TimeFactor = 0.2f;
    float elapsedTime = 0;
    bool InputGiven = false;
    bool DangerDone = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        if (DangerDone)
        {
            if (Input.GetAxis("Damage") > 0)
            {
                DangerDone = false;
                InputGiven = true;
            }
        }
        if (InputGiven)
        {
            Danger();
        }
    }

    void Danger()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (elapsedTime > 0 * TimeFactor && elapsedTime < 2 * TimeFactor)
        {
            spriteRenderer.sprite = SpriteNumber01;
        }
        else if (elapsedTime > 2 * TimeFactor && elapsedTime < 4 * TimeFactor)
        {
            spriteRenderer.sprite = SpriteNumber02;
        }
        else if (elapsedTime > 4 * TimeFactor && elapsedTime < 6 * TimeFactor)
        {
            spriteRenderer.sprite = SpriteNumber01;
        }
        else if (elapsedTime > 6 * TimeFactor)
        {
            spriteRenderer.sprite = SpriteNumber03;
            DangerDone = true;
            InputGiven = false;
        }
    }
}
