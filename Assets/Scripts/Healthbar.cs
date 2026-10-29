
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject hp10Bar;
    public GameObject hp9Bar;
    public GameObject hp8Bar;
    public GameObject hp7Bar;
    public GameObject hp6Bar;
    public GameObject hp5Bar;
    public GameObject hp4Bar;
    public GameObject hp3Bar;
    public GameObject hp2Bar;
    public GameObject hp1Bar;
    public GameObject hp0Bar;

    public void UpdateBar(int hp)
    {
        
        hp9Bar.SetActive(hp == 9);
        hp8Bar.SetActive(hp == 8);
        hp7Bar.SetActive(hp == 7);
        hp6Bar.SetActive(hp == 6);
        hp5Bar.SetActive(hp == 5);
        hp4Bar.SetActive(hp == 4);
        hp3Bar.SetActive(hp == 3);
        hp2Bar.SetActive(hp == 2);
        hp1Bar.SetActive(hp == 1);
        hp0Bar.SetActive(hp == 0);
    }
}
