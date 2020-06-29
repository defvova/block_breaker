using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int maxHits = 1;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;
    int timesHit = 0;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();

        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (CompareTag("Breakable")) level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable")) HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            PlaySoundEffect();
            AddToScore();
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void PlaySoundEffect()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void DestroyBlock()
    {
        level.BlockDestroyed();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void AddToScore()
    {
        gameStatus.AddToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
