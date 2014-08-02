/*
 * @file;
 * @brief	サウンドコントローラー;
 * @auther	Yosuke Adachi;
 * @data	2014-05-23;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

/*------------------------------------------------------------
/ サウンドコントローラー;
/------------------------------------------------------------*/
public class SoundController
{
	private static AudioSource mAudioSource = null;
	private static AudioClip[] mBgmClipList = null;
	private static AudioClip[] mSeClipList = null;
	private static int mPlayingBgmNum = 0;


	/**
	 * @brief	新しいオーディオソースを設定;
	 * @param	aAudioSource	オーディオソース;
	 * @note
	 */
	public static void setAudioSource (AudioSource aAudioSource) {
		mAudioSource = aAudioSource;
	}

	/**
	 * @brief	オーディオクリップリストの初期化(BGM);
	 * @param	aMaxClipCnt	リスト数;
	 * @note
	 */
	public static void createBgmClipList(int aMaxClipCnt)
	{
		if (mBgmClipList != null) {
			mBgmClipList = null;
		}
		mBgmClipList = new AudioClip[aMaxClipCnt];
	}

	/**
	 * @brief	オーディオクリップリストの初期化(SE);
	 * @param	aMaxClipCnt	リスト数;
	 * @note
	 */
	public static void createSeClipList(int aMaxClipCnt)
	{
		if (mSeClipList != null) {
			mSeClipList = null;
		}
		mSeClipList = new AudioClip[aMaxClipCnt];
	}
	
	/**
	 * @brief	オーディオクリップを登録(BGM);
	 * @param	aNum		クリップNo;
	 * @param	aAudioClip	登録するオーディオクリップ;
	 * @note
	 */
	public static void setBgmClipList(int aNum, AudioClip aAudioClip) {
		mBgmClipList[aNum] = aAudioClip;
	}

	/**
	 * @brief	オーディオクリップを登録(SE);
	 * @param	aNum		クリップNo;
	 * @param	aAudioClip	登録するオーディオクリップ;
	 * @note
	 */
	public static void setSeClipList(int aNum, AudioClip aAudioClip) {
		mSeClipList[aNum] = aAudioClip;
	}

	/**
	 * @brief	サウンド停止(BGM);
	 * @param	aNum	クリップNo;
	 * @param	aLoop	ループ;	
	 * @note
	 */
	public static void StopSoundBGM(int aNum)
	{
		if (mAudioSource == null || mBgmClipList[aNum] == null) return;
		
		mAudioSource.loop = false;
		mAudioSource.clip = mBgmClipList[aNum];
		mAudioSource.Stop();

		mPlayingBgmNum = -1;
	}

	/**
	 * @brief	サウンド再生(BGM);
	 * @param	aNum	クリップNo;
	 * @param	aLoop	ループ;	
	 * @note
	 */
	public static void PlaySoundBGM(int aNum, bool aLoop=true)
	{
		int bgmNum = (int)aNum;
		if (mAudioSource == null || mBgmClipList[bgmNum] == null) return;
		
		// 再生中のサウンドがある場合停止.
		if (mAudioSource.isPlaying) {
			mAudioSource.Stop();
		}
		
		mAudioSource.loop = aLoop;
		mAudioSource.clip = mBgmClipList[bgmNum];
		mAudioSource.Play();
		
		mPlayingBgmNum = bgmNum;
	}

	/**
	 * @brief	サウンド再生(SE);
	 * @param	aNum		クリップNo;
	 * @note		単発でのみ再生可能;
	 */
	public static void PlaySoundSE(int aNum)
	{
		int seNum = (int)aNum;
		if (mAudioSource == null || mSeClipList[seNum] == null ) return;
		mAudioSource.PlayOneShot (mSeClipList[seNum]);
	}

	/***********************
	 *  再生中のBGM番号取得.;
	 ***********************/

	/**
	 * @brief	再生中のBGM番号取得;
	 * @return	BGMのクリップNo;
	 * @note
	 */
	public static int getBgmNum() {
		return mPlayingBgmNum;
	}

}
