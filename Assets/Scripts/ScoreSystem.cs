using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int Score = 0;

    public int UpdateScore()
    {
        return Score++;
    }
}
