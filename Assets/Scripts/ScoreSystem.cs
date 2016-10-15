using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int Score = 0;

    public void UpdateScore()
    {
        Score++;
    }
}
