using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }

    public float MasterVolume { get { return MasterVolume; } set { MasterVolume = 1f; } }
    public float BGMVolume { get { return BGMVolume; } set { BGMVolume = 1f; } }
    public float SFXVolume { get { return SFXVolume; } set { SFXVolume = 1f; } }

}