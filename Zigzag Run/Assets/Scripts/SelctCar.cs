using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelctCar : MonoBehaviour
{
    [SerializeField] Button prevBtn;
    [SerializeField] Button nextBtn;
    [SerializeField] Button useBtn;
    [SerializeField] GameObject buyPanel;

    int currentCar;
    string ownCarIndex;
    Color redColor = new Color(1f, 0.1f, 0.1f, 1f);
    Color greenColor = new Color(0.5f, 1f, 0.4f, 1f);

    private void Awake(){
       Changecar(0);
    }

    void Choosecar(int _index){
        
    }

    void Changecar(int _change){
        currentCar += _change;
        Choosecar(currentCar);
    }
}
