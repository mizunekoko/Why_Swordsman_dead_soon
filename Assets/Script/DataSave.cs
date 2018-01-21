using UnityEngine;
using NCMB;

public class DataSave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SavePlayerData("AAA", 100, 300);
	}
	
	public void SavePlayerData(string playerName, int score, int coin){
		NCMBObject obj = new NCMBObject("PlayerData");
		
		obj.Add("PlayerName", playerName);
		obj.Add("Score", score);
		obj.Add("Coin", coin);

		obj.SaveAsync((NCMBException e) =>
		{
			if(e != null){
				Debug.Log("保存失敗、通信環境を確認してください。");
			}else{
				Debug.Log("保存成功！");
			}
		});
	}
}
