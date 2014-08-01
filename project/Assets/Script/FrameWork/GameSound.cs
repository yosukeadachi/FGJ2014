/*
 * @file;
 * @brief	ゲームサウンド;
 * @auther	Yosuke Adachi;
 * @data	2014-05-23;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

/*------------------------------------------------------------
/ ゲームサウンド;
/------------------------------------------------------------*/
public class GameSound : MonoBehaviour
{
	// サウンド情報;
	public enum BgmList : int {
		NON = 0,
		RESULT_OK,
		SOUND_MAX
	}
	public enum SeList : int {
		NON = 0,
		GAME_START,
		SOUND_MAX
	}
	public AudioClip bgm_result_ok;
	public AudioClip se_game_start;
	private AudioSource mAudioSource = null;


	/**
	 * @brief	初期化;
	 * @note
	 */
	void Start()
	{
		// サウンドソース設定;
		mAudioSource = GetComponent(typeof(AudioSource)) as AudioSource;
		SoundController.setAudioSource(mAudioSource);

		// サウンドコントローラ初期化;
		SoundController.createBgmClipList((int)BgmList.SOUND_MAX);						// BGM;
		SoundController.setBgmClipList((int)BgmList.RESULT_OK, bgm_result_ok);

		SoundController.createSeClipList((int)SeList.SOUND_MAX);						// SE;
		SoundController.setSeClipList((int)SeList.GAME_START, se_game_start);
	}
}
