using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Diary : MonoBehaviour
{
    public static bool Diary1 = false;
    public static bool Diary2 = false;
    public static bool Diary3 = false;
    public static bool Diary4 = false;
    public static bool Diary5 = false;
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        
        if(!checkDiaryCollected(getDiaryIndex(this.gameObject.name))){
            collectSound.Play();
            CollectingSystem.theScore += 1;
            setThisDiary(getDiaryIndex(this.gameObject.name));
        }
    }
    int getDiaryIndex(string n){
        if (n == "Diary 1")
        {
            return 1;
        }
        else if (n == "Diary 2")
        {
            return 2;
        }
        else if (n == "Diary 3")
        {
            return 3;
        }
        else if (n == "Diary 4")
        {
            return 4;
        }
        else if (n == "Diary 5")
        {
            return 5;
        }
        else
        {
            return 0;
        }
    }
    bool checkDiaryCollected(int i){
        switch(i){
            case 1:
                return Diary1;
                break;
            case 2:
                return Diary2;
                break;
            case 3:
                return Diary3;
                break;
            case 4:
                return Diary4;
                break;
            case 5:
                return Diary5;
                break;
            default:
                return false;

        }
    }
    void setThisDiary(int index){
        switch(index){
            case 1:
                Diary1 = true;
                break;
            case 2:
                Diary2 = true;
                break;
            case 3:
                Diary3 = true;
                break;
            case 4:
                Diary4 = true;
                break;
            case 5:
                Diary5 = true;
                break;
        }
    }
}
