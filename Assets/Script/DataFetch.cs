using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class DataFetch : MonoBehaviour {

	// Use this for initialization
	void Start () {

		FetchScoreList(10);

	}

	private void FetchScoreList(int higherThan){

		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("PlayerData");

		query.WhereGreaterThan("Score", higherThan);  //条件の設定

		query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
		{
			if(e != null){
				//エラー処理
			}else{
				//成功時の処理
				foreach(NCMBObject obj in objList){

					Debug.Log("PlayerName : " + obj["PlayerName"]+
							  ", Score :" + obj["Score"] +
							  ", Coin :" + obj["Coin"]
							);
				}
			}
		});

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
