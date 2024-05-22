using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    public int combo;
    public bool serang;
    public float comboResetTime = 1.0f; // Waktu tunggu untuk reset combo
    private float lastAttackTime; // Waktu serangan terakhir

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        combo = 0; // Mulai dari combo 0
    }

    // Update is called once per frame
    void Update()
    {
        Combos();
        ResetComboWithTime();
    }

    public void StartCombo()
    {
        serang = false;
        if (combo < 3)
        {
            combo++;
            
        }

        
    }

    public void FinishCombo()
    {
        serang = false;
        combo = 0;
    }

    private void Combos()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !serang)
        {
            serang = true;
            lastAttackTime = Time.time;
            animator.SetTrigger("" + combo);
            pushCombo();
        }
    }

    private void pushCombo()
    {
        Vector2 push = rb.transform.position;
        push.x *= 10f;
    }

    private void ResetComboWithTime()
    {
        if (Time.time - lastAttackTime > comboResetTime && combo > 0)
        {
            combo = 0;
        }
    }
}
