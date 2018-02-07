﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image heroHealth;
    public Image enemyHealth;

    private float hitpoint = 100;
    private float maxHitpoint = 100;

    private float enemyhitpoint = 100;
    private float enemymaxHitpoint = 100;

    public float damage = 20;
    public float yScale = 0.5f;

    public CameraShake cam;
    GameManager manager;

    public bool endGame = false;
    public bool hasWon = false;
	void Start () {
        UpdateHealthBar();
        EnemyHealthBar();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            EnemyDamage();
        }
    }




    private void UpdateHealthBar()
    {
        float ratio = hitpoint / maxHitpoint;
        heroHealth.rectTransform.localScale = new Vector3(ratio, 0.5f, 1);
    }

    private void EnemyHealthBar()
    {
        float enemyratio = enemyhitpoint / enemymaxHitpoint;
        enemyHealth.rectTransform.localScale = new Vector3(enemyratio, 0.5f, 1);
    }

    public void TakeDamage()
    {
        cam.ShakeCamera(5, .5f);

        hitpoint -= damage;

        if(hitpoint <= 0)
        {
            hitpoint = 0;
            Debug.Log("YOU LOSE");
            manager.BlockCoroutine();
            endGame = true;
        }

        UpdateHealthBar();
    }

    public void EnemyDamage()
    {
        enemyhitpoint -= damage;

        if (enemyhitpoint <= 0)
        {
            enemyhitpoint = 0;
            Debug.Log("YOU WON");
            manager.BlockCoroutine();
            endGame = true;
            hasWon = true;
        }

        EnemyHealthBar();
    }
}
