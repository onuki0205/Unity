using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;       // 弾のプレハブ
    [SerializeField] Transform gunBarrelEnd;        // 銃口(弾の発射位置)

    [SerializeField] ParticleSystem gunParticle;    // 発射時演出
    [SerializeField] AudioSource gunAudioSource;    // 発射音の音源

    [SerializeField] float bulletInterval = 0.5f;   // 弾を発射する間隔

    void OnEnable()
    {
        // 2秒後に弾を連続で発射する
        InvokeRepeating("Shoot", 2.0f, bulletInterval);
    }

    void OnDisable()
    {
        // Shoot処理を停止する
        CancelInvoke("Shoot");
    }

    // 弾を撃ったときの処理
    void Shoot()
    {
        // プレハブを元に、シーン上に弾を生成
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

        // 発射時演出を再生
        gunParticle.Play();

        // 発射時の音を再生
        gunAudioSource.Play();
    }
}