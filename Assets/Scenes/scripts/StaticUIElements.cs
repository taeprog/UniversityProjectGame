using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticUIElements : MonoBehaviour
{
    #region Singleton
    public static StaticUIElements instance;


    private void Awake()
    {
        instance = this;
    }
    #endregion

    public EnemyHealthBar enemyHealthBar;
    public DeadWindow deadWindow;
}
