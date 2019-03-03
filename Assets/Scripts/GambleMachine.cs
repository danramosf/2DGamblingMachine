using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GambleMachine : MonoBehaviour {

    private int[] rndNums = new int[3];
    private int[] usrNums = new int[3];

    [SerializeField] UnityEngine.UI.Dropdown dropdown_n1;
    [SerializeField] UnityEngine.UI.Dropdown dropdown_n2;
    [SerializeField] UnityEngine.UI.Dropdown dropdown_n3;

    [SerializeField] Text msg;


    public void OnPressGamble()
    {
        Debug.Log("Gamble button pressed!");
        SetUserNums();
        SortNumbers();

        Debug.Log("User numbers: " + usrNums[0] + ", " + usrNums[1] + ", " + usrNums[2] + ".");
        Debug.Log("Sorted numbers: " + rndNums[0] + ", " + rndNums[1] + ", " + rndNums[2] + ".");

        if (usrNums.SequenceEqual(rndNums))
        {
            Debug.Log("User win.");
            ((SceneLoader)this.GetComponent("SceneLoader")).LoadNextScene();
        }
        else
        {
            Debug.Log("User loses.");
            ((SceneLoader)this.GetComponent("SceneLoader")).LoadNextScene();
        }
    }

    /**
     * Gets any array of numbers and assigns a number between 1 and 7 (inclusive) for each element.
     */ 
    private void SortNumbers()
    {

        System.Random random = new System.Random();

        for (int i = 0; i < rndNums.Length; i++)
        {
            rndNums[i] = random.Next(1, 8);
        }

        //foreach (int i in rndNums)
        //{
        //    rndNums[i] = random.Next(1, 8);
        //}
    }

    /**
     * Get the numbers from the dropboxes on the UI and save them in the int array.
     */ 
    private void SetUserNums()
    {
        usrNums[0] = dropdown_n1.value + 1;
        usrNums[1] = dropdown_n2.value + 1;
        usrNums[2] = dropdown_n3.value + 1;
    }
}
