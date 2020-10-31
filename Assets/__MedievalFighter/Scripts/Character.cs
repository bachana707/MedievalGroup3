using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{





    private void OnTriggerEnter(Collider other) {


        if (other.gameObject.CompareTag("PickableObject")) {
            if (other.GetComponent<PickableObject>() != null) {
                PickableObject jeka = other.GetComponent<PickableObject>();
                PickableType tempType = jeka.ReturnType();
                switch (tempType) {
                    case PickableType.Coin:
                        Debug.Log("sasdadasdad");
                        Destroy(other.gameObject);
                        break;
                    case PickableType.Gem:
                        Debug.Log("Avige Gem");
                        Destroy(other.gameObject);
                        break;
                    case PickableType.Health:
                        break;
                    case PickableType.Weappon:
                        break;
                    case PickableType.Secret:
                        break;
                    default:
                        break;
                }
            }
        }
       


       
    }

}
