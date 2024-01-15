using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage=1; 

    /* sadece bu int de�eri i�in ve Player controllerdeki collision i�lemi i�in bu script var gibi, int de�erini healthin kendi i�inde yapabilirdik ve player controllerdeki collision i�lemi i�in layer ya da tag kullanabilirdik asl�nda
     */
    public int HitDamage => damage;

    public void HitTarget(Heath health)
    {
        health.TakeHit(this);
    }


}
