using System;
using Raylib_cs;

namespace ColaGameLib.core.audio;

public class AudioManager : IDisposable
{
    private Music? _activeMusic;
    private bool _disposed;

    public bool IsReady => Raylib.IsAudioDeviceReady();
    public float MasterVolume => Raylib.GetMasterVolume();

    public AudioManager()
    {
        Raylib.InitAudioDevice();
    }

    // This must be called once per frame by the Game Loop to keep music buffers filled
    public void Update()
    {
        if (_activeMusic.HasValue && Raylib.IsMusicStreamPlaying(_activeMusic.Value))
        {
            Raylib.UpdateMusicStream(_activeMusic.Value);
        }
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

    public bool IsMusicPlaying(Music music) => Raylib.IsMusicStreamPlaying(music);
    public float GetMusicLength(Music music) => Raylib.GetMusicTimeLength(music);
    public float GetMusicTimePlayed(Music music) => Raylib.GetMusicTimePlayed(music);

    // Activates and plays a stream, automatically stopping the previous track
    public void PlayMusic(Music music, bool isLooping = true)
    {
        if (_activeMusic.HasValue && _activeMusic.Value.Equals(music))
        {
            if (!Raylib.IsMusicStreamPlaying(music))
            {
                Raylib.PlayMusicStream(music);
            }
            return;
        }

        StopMusic();

        _activeMusic = music;
        
        var musicStruct = _activeMusic.Value;
        musicStruct.Looping = isLooping;
        _activeMusic = musicStruct;

        Raylib.PlayMusicStream(music);
    }

    public void PauseMusic()
    {
        if (_activeMusic.HasValue)
        {
            Raylib.PauseMusicStream(_activeMusic.Value);
        }
    }

    public void ResumeMusic()
    {
        if (_activeMusic.HasValue)
        {
            Raylib.ResumeMusicStream(_activeMusic.Value);
        }
    }

    public void StopMusic()
    {
        if (_activeMusic.HasValue)
        {
            Raylib.StopMusicStream(_activeMusic.Value);
            _activeMusic = null;
        }
    }

    public void SeekMusic(float position)
    {
        if (_activeMusic.HasValue)
        {
            Raylib.SeekMusicStream(_activeMusic.Value, position);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (_activeMusic.HasValue)
        {
            Raylib.SetMusicVolume(_activeMusic.Value, volume);
        }
    }

    public void SetMusicPitch(float pitch)
    {
        if (_activeMusic.HasValue)
        {
            Raylib.SetMusicPitch(_activeMusic.Value, pitch);
        }
    }

    public void SetMusicPan(float pan)
    {
        if (_activeMusic.HasValue)
        {
            Raylib.SetMusicPan(_activeMusic.Value, pan);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                StopMusic();
            }

            if (Raylib.IsAudioDeviceReady())
            {
                Raylib.CloseAudioDevice();
            }
            
            _disposed = true;
        }
    }

    ~AudioManager()
    {
        Dispose(false);
    }
}