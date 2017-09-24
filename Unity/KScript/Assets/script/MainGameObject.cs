﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/*
 * 1 Attaquer				#D43635
 * 2 Attaque groupe			#D43635
 * 3 Transporter			#7EAD3D
 * 4 Stationner				#36B588
 * 5 Stationner defendre	#D57936
 * 6 Espionner				#BD9B2F
 * 7 Coloniser				#2BBFBF
 * 8 Recycler				#11A140
 * 9 Detruire				#FF3356
 * 15 Expedition			#4162A5
 */

public class MainGameObject : MonoBehaviour {
	public GameObject bodyFleet;
	// Use this for initialization
	void Start () {
		GameObject.Find("Canvas").GetComponent<getDataQrCode>().jsonToList();

		var listFleet = GameObject.Find("Canvas").GetComponent<getDataQrCode>().listFleet;

		foreach (var obj in listFleet) {
			GameObject go = Instantiate(bodyFleet) as GameObject;
			var color = "FFFFFF";
			go.SetActive(true);

			switch (int.Parse(obj.missionType)) {
				case 1:
					color = "D43635";
				break;
				case 2:
					color = "D43635";
				break;
				case 3:
					color = "7EAD3D";
				break;
				case 4:
					color = "36B588";
				break;
				case 5:
					color = "D57936";
				break;
				case 6:
					color = "BD9B2F";
				break;
				case 7:
					color = "2BBFBF";
				break;
				case 8:
					color = "11A140";
				break;
				case 9:
					color = "FF3356";
				break;
				case 15:
					color = "4162A5";
				break;
			}
			if (obj.isReturn == "true")
				color += "AA";
			else 
				color += "FF";

			foreach (var item in go.GetComponentsInChildren<Text>()) {
				if (item.name == "destCoords")
					item.text = obj.destCoords;
				else if (item.name == "originFleet")
					item.text = obj.originFleet;
				else if (item.name == "destFleet")
					item.text = obj.destFleet;
				else if (item.name == "sizeFleet")
					item.text = obj.sizeFleet;
				item.color = HexToColor(color);
			}
			foreach (var item in go.GetComponentsInChildren<Image>()) {
				if (item.name == "returnFleet")
					if (obj.isReturn == "true")
						item.enabled = true;
				if (item.name == "startFleet")
					if (obj.isReturn == "false")
						item.enabled = true;
			}
			go.GetComponent<bodyFleet>().timeStampValue = int.Parse(obj.timeStamp);
			go.GetComponent<bodyFleet>().refreshTime();
			go.transform.SetParent(bodyFleet.transform.parent);
			go.transform.localScale = new Vector3(1, 1, 1);
		}
	}
	
	void Update () {
		
	}

	void FixedUpdate() {
		foreach (var fleet in GameObject.FindGameObjectsWithTag("bodyFleet")) {
			fleet.GetComponent<bodyFleet>().refreshTime();
		}
	}

	private void refreshListFleet() {

	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		byte a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, a);
	}
}