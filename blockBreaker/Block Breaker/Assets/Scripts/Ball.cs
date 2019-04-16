using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  [SerializeField] Paddle paddle1;
  [SerializeField] float xPush = 2f;
  [SerializeField] float yPush = 15f;
  [SerializeField] AudioClip[] ballsounds;

  bool hasStarted = false;
  AudioSource myAudioSource;

  Vector2 paddleToBallVector;
  // Start is called before the first frame update
  void Start()
  {
    paddleToBallVector = transform.position - paddle1.transform.position;
    myAudioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!hasStarted)
    {
      LockBallToPaddle();
      LaunchOnMouseClick();
    }
  }

  private void LaunchOnMouseClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      hasStarted = true;
      GetComponent<Rigidbody2D>().velocity = new Vector2 (xPush, yPush);
    }
  }

  private void LockBallToPaddle()
  {
    Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
    transform.position = paddlePos + paddleToBallVector;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (hasStarted)
    {
      AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
      myAudioSource.PlayOneShot(clip);
    }
  }
}
