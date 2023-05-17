using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Moneycolect : MonoBehaviour
{
    public float money;
    public Sprite openBox;
    private SpriteRenderer renderer;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            MainCharacter player=other.GetComponent<MainCharacter>();
            //SoundManager sound=FindAnyObjectByType<SoundManager>();
            //sound.SeleccionAudios(0, 0.05f);
            player.GetMoney(money);
            if(gameObject.CompareTag("Box"))
            {
                renderer=GetComponent<SpriteRenderer>();
                renderer.sprite=openBox;
            }
            else
            {
               Destroy(gameObject); 
            }
        }
    }
}
