using Raylib_cs;

namespace ColaGameLib.core.audio;

public class AudioManager
{
    public bool IsReady() => Raylib.IsAudioDeviceReady();

    public float MasterVolume => Raylib.GetMasterVolume();

    public AudioManager()
    {
        Raylib.InitAudioDevice();
    }

    public bool IsSoundPlaying(Sound sound) => Raylib.IsSoundPlaying(sound);

    public void PlaySound(Sound sound)
    {
        Raylib.PlaySound(sound);
    }

    public void StopSound(Sound sound)
    {
        Raylib.StopSound(sound);
    }

    public void PauseSound(Sound sound)
    {
        Raylib.PauseSound(sound);
    }

    public void SetMasterVolume(float volume)
    {
        Raylib.SetMasterVolume(volume);
    }

    public void SetSoundVolume(Sound sound, float volume)
    {
        Raylib.SetSoundVolume(sound, volume);
    }

    public void SetSoundPitch(Sound sound, float pitch)
    {
        Raylib.SetSoundPitch(sound, pitch);
    }

    public void UnloadSound(Sound sound)
    {
        Raylib.UnloadSound(sound);
    }
    
    // -------------------------
    // MUSIC
    // -------------------------

    public bool IsMusicPlaying(Music music) => Raylib.IsMusicStreamPlaying(music);

    public float GetMusicLength(Music music) => Raylib.GetMusicTimeLength(music);

    public float GetMusicTimePlayed(Music music) => Raylib.GetMusicTimePlayed(music);

    public void PlayMusic(Music music)
    {
        Raylib.PlayMusicStream(music);
    }

    public void PauseMusic(Music music)
    {
        Raylib.PauseMusicStream(music);
    }

    public void ResumeMusic(Music music)
    {
        Raylib.ResumeMusicStream(music);
    }

    public void StopMusic(Music music)
    {
        Raylib.StopMusicStream(music);
    }

    public void SeekMusic(Music music, float position)
    {
        Raylib.SeekMusicStream(music, position);
    }

    public void SetMusicVolume(Music music, float volume)
    {
        Raylib.SetMusicVolume(music, volume);
    }

    public void SetMusicPitch(Music music, float pitch)
    {
        Raylib.SetMusicPitch(music, pitch);
    }

    public void SetMusicPan(Music music, float pan)
    {
        Raylib.SetMusicPan(music, pan);
    }

    public void UnloadMusic(Music music)
    {
        Raylib.UnloadMusicStream(music);
    }
    
    ~AudioManager()
    {
        Raylib.CloseAudioDevice();
    }
}