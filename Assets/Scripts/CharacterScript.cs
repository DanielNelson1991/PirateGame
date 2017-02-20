using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    public float _MoveSpeed = 0;
    public GameObject _CannonSprite;
    public GameObject _Loncation;
    private bool _IsMoving;

    // Use this for initialization
	void Start () {
        _IsMoving = false;
	}
	
	// Update is called once per frame
	void Update () {




        if(Input.GetMouseButton(0))
        {
            _IsMoving = true;
            
        }

        if(_IsMoving)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -mousePos - transform.position);

            transform.position = Vector2.MoveTowards(transform.position, mousePos, 1 * Time.deltaTime);
            if(Vector2.Distance(transform.position, mousePos) < 0.1f)
            {
                _IsMoving = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().Play();
            GameObject temp = Instantiate(_CannonSprite, _Loncation.transform.position, _Loncation.transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 200 * Time.deltaTime, ForceMode2D.Impulse);
            Destroy(temp, 5);
        }
	}
}
