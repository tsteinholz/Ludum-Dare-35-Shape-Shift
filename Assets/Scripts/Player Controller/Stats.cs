using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
    
    [Range(1, 100)]
    public int level;
    public int health;
    public int experience;
    int experienceToNextLevel;

    void Start()
    {
        health = 10;
        level = 1;
        experienceToNextLevel = level * 100 / 2;
        experience = 0;
    }

    void updateLevel()
    {
        if(experience == experienceToNextLevel){
            levelUp();
        }
    }

    void levelUp()
    {
        level++;
        experience = experience - experienceToNextLevel;
        experienceToNextLevel = level * 100 / 2;
        health += (int)(level / 2);
    }

    int getLevel()
    {
        return level;
    }

    int getHealth()
    {
        return health;
    }
}
