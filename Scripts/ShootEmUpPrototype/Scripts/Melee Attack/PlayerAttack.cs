using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    [SerializeField] public float damage;

    public float timeBetweenAttacking;
    public bool canAttack;
    private float timer;

    public AudioSource swordSFX;
    private void Update()
    {
        
        //Press right mousebutton to start melee attack animation.
        //canAttack set to false so you cant attack again until timer runs out.
        if (Input.GetMouseButton(1) && canAttack)
        {
            canAttack = false;
            swordSFX.Play();
            anim.SetTrigger("Attack");
            swordSFX.Play();
        }

        //Cooldown timer between melee attacks.
        if (!canAttack)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenAttacking)
            {
                canAttack = true;
                timer = 0;
            }
        }

    }

    

}
