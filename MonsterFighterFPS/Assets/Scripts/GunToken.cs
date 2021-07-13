using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunToken : MonoBehaviour {

	[SerializeField] GameObject _collectedGun;
	[SerializeField] GameObject _weaponHolster;
	GameObject _weaponParent;
	const string WEAPON_PARENT_NAME = "Weapons";

	void CreatePlayerParent() {
		_weaponParent = GameObject.Find(WEAPON_PARENT_NAME);

		if(!_weaponParent) {
			_weaponParent = new GameObject(WEAPON_PARENT_NAME);
		}
	}

	void InstantiateCharacter() {
		GameObject newCharacter = Instantiate(_collectedGun, _weaponHolster.transform.position, Quaternion.identity);

		newCharacter.transform.parent = _weaponParent.transform;
		newCharacter.gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Touched");
		CreatePlayerParent();
		InstantiateCharacter();
		Destroy(gameObject);
	}
}

/*	TODO: STEPS: 

	X.) When Player sees token, collect it
	X.) Token disappears
	X.) In the Hierarchy, new character is child under the Player parent
	4.) New current character is active on previous character location
	5.) Each time a character is switched, their posisition should be the same
	
 */