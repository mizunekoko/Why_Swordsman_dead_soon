using UnityEngine;
using NCMB;

public class UserAuth : MonoBehaviour {

	public string userName;
	public string password;
	public string email;

	// Use this for initialization
	void Start () {
		//SignUp(userName, password, email);

		LogIn(userName, password);
	}
	
	public void SignUp(string userName, string password, string email){
	
		NCMBUser user = new NCMBUser();

		user.UserName = userName;
		user.Password = password;
		user.Email = email;

		user.SignUpAsync((NCMBException e) =>
		{
			if(e != null){
				//エラー 表示
				Debug.Log("新規登録に失敗　：" + e.ErrorMessage);
			}else{
				Debug.Log("新規登録に成功");
			}
		});
	}

	public void LogIn(string userName, string password){

		NCMBUser.LogInAsync(userName, password, (NCMBException e) =>
		{
			if(e != null){
				Debug.Log("ログイン失敗");
			}else{
				Debug.Log("ログイン成功！");
				SetPoint(10);
			}

		});

	}


	public void SetPoint(int num){

		if(NCMBUser.CurrentUser != null){

			NCMBUser.CurrentUser["Point"] = num;

			NCMBUser.CurrentUser.SaveAsync((NCMBException e) =>
			{
				if(e != null){
					Debug.Log("保存失敗 ：" + e.ErrorMessage);
		
				}else{
					Debug.Log("保存に成功！");
					//int point =  (int)NCMBUser.CurrentUser["Point"];
					//Debug.Log("Point : " + point);
				}

			});

		}

	}

	public void LogOut(){

		NCMBUser.LogOutAsync((NCMBException e) =>
		{
			if(e != null){

				Debug.Log("ログアウトに失敗 : " + e.ErrorMessage);

			}else{

				Debug.Log("ログアウトに成功！");

			}

		});

	}

}
