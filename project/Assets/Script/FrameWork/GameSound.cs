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
		TITLE,
		PLAY,
		SOUND_MAX
	}
	public enum SeList : int {
		NON = 0,
		GAME_START,
		GAME_SMASH,
		GAME_RESULT,
		SOUND_MAX
	}
	public AudioClip bgm_title;
	public AudioClip se_game_start;
	// ここに追加?;
	public AudioClip bgm_play;
	public AudioClip se_game_smash;
	public AudioClip se_game_result;

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
		SoundController.setBgmClipList((int)BgmList.TITLE, bgm_title);
		SoundController.setBgmClipList((int)BgmList.PLAY, bgm_play);

		SoundController.createSeClipList((int)SeList.SOUND_MAX);						// SE;
		SoundController.setSeClipList((int)SeList.GAME_START, se_game_start);
		SoundController.setSeClipList((int)SeList.GAME_SMASH, se_game_smash);
		SoundController.setSeClipList((int)SeList.GAME_RESULT, se_game_result);
	}
}
