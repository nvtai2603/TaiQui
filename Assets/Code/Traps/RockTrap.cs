
using UnityEngine;

public class RockTrap : SpikeTrap
{
    [Header("RockTrap Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] dirs = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool atk;

    

    //private void OnEnable()
    //{
    //    Stop();
    //}

    private void Update()
    {
        if(atk)
        transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
    }

    private void CheckForPlayer()
    {
        CalculateDir();
        for(int i = 0; i < dirs.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirs[i], range, playerLayer);

            if(hit.collider != null && !atk)
            {
                atk = true;
                destination = dirs[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDir()
    {
        
        dirs[0] = transform.up * range;
        dirs[1] = -transform.up * range;
    }

    //private void Stop()
    //{
    //    destination = transform.position;
    //    atk = false;
    //}

    private void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        //Stop();
    }
}
