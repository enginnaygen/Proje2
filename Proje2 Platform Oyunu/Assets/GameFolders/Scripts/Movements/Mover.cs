using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{ 
    [SerializeField] int speed = 5;

    public void MoveAction(float horizontal,Transform transform)
    {
        transform.Translate(horizontal * Time.deltaTime * Vector2.right * speed);

        if (horizontal != 0) /* bu þekilde yapmamýzýn sebebi playerý hareket ettirdikten sonra sürekli saða bakýyor olmasýný engellemek, 0'ken en son hangi yöne bakýyorsa o yöne bakýyor olarak kalmasýný saðlamak*/
        {
            transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f);
        }


    }
}
