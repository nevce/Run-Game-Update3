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
    float doubleTapCooldown = 0.5f; // Ýki týklama arasýndaki minimum süre
    float lastTapTime; // Son týklama zamaný

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
        // Þu anki zamaný al
        float currentTime = Time.time;

        // Eðer son týklama zamaný ile þu anki zaman arasýndaki fark
        // `doubleTapCooldown` süresinden küçükse, ikinci týklamayý engelle
        if (currentTime - lastTapTime < doubleTapCooldown)
        {
            Debug.Log("Double Tap Prevented");
            return;
        }

        // Ýlk týklamadan sonraki týklamalarda bu deðeri güncelle
        lastTapTime = currentTime;

        // Ýlk týklama iþlemini burada gerçekleþtirin
        Debug.Log("Single Tap");
    }
}
