using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCParticle : MonoBehaviour
{
   [SerializeField] ParticleSystem collectParticle = null;

   // To delete after testing
   private void update()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           Collect();
       }
   }
public void Collect()
 {
    // Play collected graphics
    collectParticle.Play();
    // Play the eventual collect sound effect
 }

}
