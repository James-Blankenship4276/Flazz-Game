using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Win32;
using System.IO;

namespace Flazz_Game
{
    class Sound
    {
        //Creating a new mediaplayer
        private static MediaPlayer mediaPlayer = new MediaPlayer();

        //Opening music file
        public static void OpenMusic(string relativePath)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                mediaPlayer.Play();
            }
        }

        //Playing the music
        public static void PlayBackgroundMusic()
        {
            mediaPlayer.Open(new Uri(Path.Combine(Environment.CurrentDirectory, @"C:\Users\blank\Downloads\Project proposal\Project Proposal\Project-Proposal-Draft-Flash\Project-Proposal-Draft-Flash\Flazz Game\Sound\bensound-theelevatorbossanova.mp3")));
            mediaPlayer.Play();
        }

        //Muting to the music
        public static void MuteBackgroundMusic()
        {
            mediaPlayer.Stop();
        }
    }
}
