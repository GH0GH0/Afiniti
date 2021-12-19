using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScripts : MonoBehaviour
{
    
   public GameObject menu1;
    void Start() {
       menu1.gameObject.SetActive(false);
    }
   

   public void afficher_menu1(){
       menu1.gameObject.SetActive(true);
   }
}
