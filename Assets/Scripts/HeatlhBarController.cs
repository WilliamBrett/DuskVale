using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatlhBarController : MonoBehaviour
{
    private HealthManager PCHM;
    public Slider thisSlider;
    public TextMeshProUGUI thisText;
    //private text
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PCHM)
        {
            thisSlider.value = PCHM.currenthealth;
            thisText.text = (PCHM.currenthealth).ToString();
        }
        else
        {
            GameObject[] PCs = GameObject.FindGameObjectsWithTag("Player");
            if (PCs.Length != 0)
            {
                GameObject PlayerRef = PCs[0];
                PCHM = PlayerRef.GetComponent<HealthManager>();
                thisSlider.maxValue = PCHM.maxhealth;
                thisSlider.value = PCHM.currenthealth;
            }
        }
    }
}
