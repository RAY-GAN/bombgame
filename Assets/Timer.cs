using UnityEngine;
using System.Collections;
using System;

public delegate void CompleteEvent();
public delegate void UpdateEvent(float t);

public class Timer : MonoBehaviour
{
    bool isLog = true;

    UpdateEvent updateEvent;

    CompleteEvent onCompleted;

    float timeTarget;   // ��ʱʱ��/

    float timeStart;    // ��ʼ��ʱʱ��/

    float timeNow;     // ����ʱ��/

    float offsetTime;   // ��ʱƫ��/

    bool isTimer;       // �Ƿ�ʼ��ʱ/

    bool isDestory = true;     // ��ʱ�������Ƿ�����/

    bool isEnd;         // ��ʱ�Ƿ����/

    bool isIgnoreTimeScale = true;  // �Ƿ����ʱ������

    bool isRepeate;

    float Time_
    {
        get { return isIgnoreTimeScale ? Time.realtimeSinceStartup : Time.time; }
    }
    float now;
    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            timeNow = Time_ - offsetTime;
            now = timeNow - timeStart;
            if (updateEvent != null)
                updateEvent(Mathf.Clamp01(now / timeTarget));
            if (now > timeTarget)
            {
                if (onCompleted != null)
                    onCompleted();
                if (!isRepeate)
                    destory();
                else
                    reStartTimer();
            }
        }
    }
    public float GetLeftTime()
    {
        return Mathf.Clamp(timeTarget - now, 0, timeTarget);
    }
    void OnApplicationPause(bool isPause_)
    {
        if (isPause_)
        {
            pauseTimer();
        }
        else
        {
            connitueTimer();
        }
    }

    /// <summary>
    /// ��ʱ����
    /// </summary>
    public void destory()
    {
        isTimer = false;
        isEnd = true;
        if (isDestory)
            Destroy(gameObject);
    }
    float _pauseTime;
    /// <summary>
    /// ��ͣ��ʱ
    /// </summary>
    public void pauseTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("��ʱ�Ѿ�������");
        }
        else
        {
            if (isTimer)
            {
                isTimer = false;
                _pauseTime = Time_;
            }
        }
    }
    /// <summary>
    /// ������ʱ
    /// </summary>
    public void connitueTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("��ʱ�Ѿ�����������¼�ʱ��");
        }
        else
        {
            if (!isTimer)
            {
                offsetTime += (Time_ - _pauseTime);
                isTimer = true;
            }
        }
    }
    public void reStartTimer()
    {
        timeStart = Time_;
        offsetTime = 0;
    }

    public void changeTargetTime(float time_)
    {
        timeTarget += time_;
    }
    /// <summary>
    /// ��ʼ��ʱ : 
    /// </summary>
    public void startTiming(float time_, CompleteEvent onCompleted_, UpdateEvent update = null, bool isIgnoreTimeScale_ = true, bool isRepeate_ = false, bool isDestory_ = true)
    {
        timeTarget = time_;
        if (onCompleted_ != null)
            onCompleted = onCompleted_;
        if (update != null)
            updateEvent = update;
        isDestory = isDestory_;
        isIgnoreTimeScale = isIgnoreTimeScale_;
        isRepeate = isRepeate_;

        timeStart = Time_;
        offsetTime = 0;
        isEnd = false;
        isTimer = true;

    }
    /// <summary>
    /// ������ʱ��:����
    /// </summary>
    public static Timer createTimer(string gobjName = "Timer")
    {
        GameObject g = new GameObject(gobjName);
        Timer timer = g.AddComponent<Timer>();
        return timer;
    }

}

