using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage=1; 

    /* sadece bu int deðeri için ve Player controllerdeki collision iþlemi için bu script var gibi, int deðerini healthin kendi içinde yapabilirdik ve player controllerdeki collision iþlemi için layer ya da tag kullanabilirdik aslýnda
     */
    public int HitDamage => damage;

    public void HitTarget(Heath health)
    {
        health.TakeHit(this);
    }


}
