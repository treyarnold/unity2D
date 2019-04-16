using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  [SerializeField] AudioClip breakSound;
  [SerializeField] GameObject blockSparklesVFX;
  [SerializeField] int maxHits;
  [SerializeField] Sprite[] hitSprites;

  Level level;
  GameSession gameStatus;

  [SerializeField] int timesHit = 0;

  private void Start()
  {
    CountBreakableBlocks();
  }

  private void CountBreakableBlocks()
  {
    level = FindObjectOfType<Level>();
    gameStatus = FindObjectOfType<GameSession>();
    if (gameObject.tag == "Breakable")
    {
      level.CountBlocks();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (gameObject.tag == "Breakable")
    {
      HandleHit();
    }
  }

  private void HandleHit()
  {
    timesHit++;
    if (timesHit >= maxHits)
    {
      DestroyBlock();
    }
    else {
      ShowNextHitSprite();
    }
  }

  private void ShowNextHitSprite()
  {
    GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
  }

  private void DestroyBlock()
  {
    PlayBlockDestroySoundFX();
    Destroy(gameObject);
    level.BlockDestroyed();
    TriggerSparklesVFX();
  }

  private void PlayBlockDestroySoundFX()
  {
    AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    gameStatus.AddToScore();
  }

  private void TriggerSparklesVFX()
  {
    GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    Destroy(sparkles, 2f);
  }
}
