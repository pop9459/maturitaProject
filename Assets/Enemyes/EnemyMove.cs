using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    [SerializeField] GameObject deathParticle;
    public float magnitude = 1f;
    float worth;
    float speed = 5;
    int waypointIndex = 0;
    Vector3 currentWp;
    float scale;
    float hue;
    bool alive;
    bool bossClass = false;

    Rigidbody rb;
    Renderer rend;
    private void Awake()
    {
        Physics.autoSyncTransforms = true;
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }
    private void OnEnable()
    {
        if(magnitude > 100) bossClass = true;
        alive = true;
        worth = magnitude;
        waypointIndex = 0;
        currentWp = Waypoints.waypoints[waypointIndex]; //set first wp
        setMagnitude(magnitude);
    }
    private void FixedUpdate()
    {
        Vector3 dir = currentWp - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;
        
        if(Vector3.Distance(gameObject.transform.position, currentWp) < 0.2f)
        {
            //reached WP
            if(waypointIndex >= Waypoints.waypoints.Length-1)
            {
                //reachead last WP
                Controller.dealDeamge(magnitude);
                disable();
            }
            else
            {
                //select next WP
                waypointIndex++;
                currentWp = Waypoints.waypoints[waypointIndex];
            }
        }
    }
    public void takeDeamge(float magn)
    {
        StartCoroutine(summonDeathParticle());
        magnitude -= magn;
        if (magnitude <= 0f && alive)
        {
            //enemy killed by player
            Controller.addMoney(worth);
            disable();
        }

        setMagnitude(magnitude); //visual
    }
    public void disable()
    {
        alive = false;
        Spawner.activeEnemyes.Remove(this);
        Spawner.enemyBuffer.Add(this);
        gameObject.SetActive(false);
    }
    //TODO
    IEnumerator summonDeathParticle()
    {
        MainAudioSource.audioSource.PlayOneShot(hitSound);
        GameObject dp = Instantiate(deathParticle, transform.position, Quaternion.identity);
        dp.SetActive(false);
        dp.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", Color.HSVToRGB(hue, 1, 1));
        dp.SetActive(true);
        //dp.GetComponent<ParticleSystem>().Play();
        //dp.GetComponent<DestroySelfAfterTime>().setDeleteTimer(2);
        yield return null;
    }
    public void setMagnitude(float magn) //funct to update visuals
    {
        magnitude = magn;

        if(bossClass)
        {
            speed = 200 / worth;
            scale = magnitude / 40;
        }
        else
        {
            speed = (magn + 5) * 1.2f;

            float scaleMulti = 0.1f;
            //visual muilipliers - balance later
            scale = 1 + (magnitude * scaleMulti); //set scale - visual
            hue = ((magnitude - 1) / 7) % 1; //set color - first 7 collors -- add special later
        }
        transform.localScale = new Vector3(scale, scale, scale);
        rend.material.SetColor("_Color", Color.HSVToRGB(hue, 1, 1));
    }
}
