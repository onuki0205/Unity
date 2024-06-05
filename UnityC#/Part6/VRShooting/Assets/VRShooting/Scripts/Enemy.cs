using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip spawnClip; // 出現時のAudioClip
    [SerializeField] AudioClip hitClip;   // 弾命中時のAudioClip

    // 倒された際に無効化するためにコライダーとレンダラーを持っておく
    [SerializeField] Collider enemyCollider; // コライダー
    [SerializeField] Renderer enemyRenderer; // レンダラー

    AudioSource audioSource; // 再生に使用するAudioSource

    void Start()
    {
        // AudioSourceコンポーネントを取得しておく
        audioSource = GetComponent<AudioSource>();

        // 出現時の音を再生
        audioSource.PlayOneShot(spawnClip);
    }

    // OnHitBulletメッセージから呼び出されることを想定
    void OnHitBullet()
    {
        // 弾命中時の音を再生
        audioSource.PlayOneShot(hitClip);

        // 死亡時処理
        GoDown();
    }

    // 死亡時処理
    void GoDown()
    {
        // 当たり判定と表示を消す
        enemyCollider.enabled = false;
        enemyRenderer.enabled = false;

        // 自身のゲームオブジェクトを一定時間後に破棄
        Destroy(gameObject, 1f);
    }
}
