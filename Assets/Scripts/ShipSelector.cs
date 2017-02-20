using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelector : MonoBehaviour {

    public Text _ShipDescription;
    public Image _SpritePlaceholder;
    private int _ShipSelectedInt;

    // Create nested class
    [System.Serializable]
    public class ShipProperties
    {
        public string _ShipName;
        public string _ShipDesc;
        public Sprite _ShipSprite;
        public int _CrewMembers;
        public float _FirePower;
    }

    public List<ShipProperties> _ShipList = new List<ShipProperties>();

	// Use this for initialization
	void Start () {
        _ShipDescription.text = _ShipList[0]._ShipDesc;
        _SpritePlaceholder.sprite = _ShipList[0]._ShipSprite;
        Mathf.Clamp(_ShipSelectedInt, 0, 1);

        Debug.Log("Ship Selected int: " + _ShipSelectedInt);
    }
	
	// Update is called once per frame
	void Update () {
		
        // Fixed it, just had to move the logic around so that you call the function after you increment, and then make sure you do a check so that we 
        // don't go beyond the ship selection count. Can we play Dirty Bomb now?
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (_ShipSelectedInt >= _ShipList.Count)
            {
                _ShipSelectedInt = _ShipList.Count;
            }
            else {
                _ShipSelectedInt++;
                SwitchShip();
            }

        } else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            if (_ShipSelectedInt < 0)
            {
                _ShipSelectedInt = 0;
            }
            else
            {
                _ShipSelectedInt--;
                SwitchShip();
            }
            
        }

	}

    void SwitchShip()
    {
        Debug.Log(_ShipSelectedInt);
        if(_ShipSelectedInt >= 0 && _ShipSelectedInt < _ShipList.Count)
        {
            // This is what is causing the array index out of range. Originally, I had it in Update with the Keycode.Right.
            // But obviously, need to go back and forth. But, incrementing the _ShipSelectedInt past the length of the list, gives me that damn error
            for (int i = 0; i < _ShipList.Count; i++)
            {
                _ShipDescription.text = _ShipList[_ShipSelectedInt]._ShipDesc;
                _SpritePlaceholder.sprite = _ShipList[_ShipSelectedInt]._ShipSprite;

                // Okay, new problem. If I keep tapping right too much, the counter goes way past the max value. Here, check it 
                if (i > _ShipList.Count) {
                    i = 0;
                }

                
            }
        }
    }
}
