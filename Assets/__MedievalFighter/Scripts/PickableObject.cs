using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PickableObject :MonoBehaviour
{
    public PickableType currentType;
    public int value;
    public PickableType ReturnType() {
        return currentType;
    }

}

public enum PickableType
{
    Coin, Gem, Health, Weappon, Secret
}
