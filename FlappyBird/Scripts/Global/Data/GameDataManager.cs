using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // data of the player pawn : it's bird
    public class SuperBird
    {
        public static SuperBird instaceSuperBird;
        public static SuperBird getInstance()
        {
            if (instaceSuperBird == null)
            {
                instaceSuperBird = new SuperBird();
            }
            return instaceSuperBird;
        }

        public int m_Blood = 100;

        public int m_Velocity = 0;

        public int m_BestScore = 0;

        public int m_CurrentScore = 0;  

        public int m_Energy = 0;
    }
}
