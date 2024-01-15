using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{ 
    [SerializeField] int speed = 5;

    public void MoveAction(float horizontal,Transform transform)
    {
        transform.Translate(horizontal * Time.deltaTime * Vector2.right * speed);

        if (horizontal != 0) /* bu �ekilde yapmam�z�n sebebi player� hareket ettirdikten sonra s�rekli sa�a bak�yor olmas�n� engellemek, 0'ken en son hangi y�ne bak�yorsa o y�ne bak�yor olarak kalmas�n� sa�lamak*/
        {
            transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f);
        }


    }
}
