using System.Collections.Generic;
using UnityEngine;

namespace Unity_Utilities.Extensions
{
    public static class AudioSourceExtenstions
    {

        public static void TryPlayRandomFromList(this AudioSource source, List<AudioClip> clips)
        {
            if (clips == null || clips.Count == 0)
            {
                Debug.LogWarning($"No clips to play for {clips}");
                return;
            }
            source.PlayOneShot(clips[Random.Range(0, clips.Count - 1)]);
        }
        public static void TryPlayRandomFromList(this AudioSource source, List<AudioClip> clips, float volume)
        {
            if (clips == null || clips.Count == 0)
            {
                Debug.LogWarning($"No clips to play for {clips}");
                return;
            }
            source.volume = volume;
            source.PlayOneShot(clips[Random.Range(0, clips.Count - 1)]);
        }
    }
}
