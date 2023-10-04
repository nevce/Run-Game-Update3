using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    public float jumpForce = 10f; 
    private Rigidbody rb;
    public bool isOnGround = true;
    private Animator anim;
    public ParticleSystem ayakIzi;
    public GameObject player;
    float doubleTapCooldown = 0.5f; // �ki t�klama aras�ndaki minimum s�re
    float lastTapTime; // Son t�klama zaman�

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();

    }

    public void OnJumpButtonClick()
    {
        Debug.Log("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        anim.SetTrigger("Jump_trig");
        ayakIzi.Stop();
    }
    public void OnDirectionButtonClick()
    {
        // �u anki zaman� al
        float currentTime = Time.time;

        // E�er son t�klama zaman� ile �u anki zaman aras�ndaki fark
        // `doubleTapCooldown` s�resinden k���kse, ikinci t�klamay� engelle
        if (currentTime - lastTapTime < doubleTapCooldown)
        {
            Debug.Log("Double Tap Prevented");
            return;
        }

        // �lk t�klamadan sonraki t�klamalarda bu de�eri g�ncelle
        lastTapTime = currentTime;

        // �lk t�klama i�lemini burada ger�ekle�tirin
        Debug.Log("Single Tap");
    }
}
