using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Ce script doit être attaché à l'objet qui contient le particles system du feu.


[RequireComponent(typeof(ParticleSystem))]

public class ToggleFireParticle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;       // On peut changer dans Unity la touche à presser.

    private ParticleSystem fireParticle;
    public ParticleSystem igniteParticle;           // Faire glisser ici par exemple nos particules Smoke Burst.
    public ParticleSystem extinguishParticle;       // Idem.
    public GameObject pointLight;                   // Ici, faire glisser la point light de notre feu.

    bool isPlaying = true;

    private void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(isPlaying)
            {
                fireParticle.Stop();
                pointLight.SetActive(false);
                if (extinguishParticle != null)         // Ces particules sont donc optionnelles.
                    extinguishParticle.Play();
                isPlaying = false;
            } 
            else
            {
                fireParticle.Play();
                pointLight.SetActive(true);
                if (igniteParticle != null)             // Idem.
                    igniteParticle.Play();
                isPlaying = true;
            }
        }
    }
}
