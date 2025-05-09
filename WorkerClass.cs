﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PlayWavFiles
{
    using System;
    using System.IO;
    using System.Media;

    class WorkerClass
    {
        // An array to track which songs have been played
        private bool[] songsPlayed = new bool[3];

        public void SongChoice()
        {
            // Loop to keep a menu running until user decides to exit
            while (true)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Which song would you like to play?");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(" ");

                // Display each song option, highlighting played songs in green
                DisplaySongOption(1, "Song 1");
                DisplaySongOption(2, "Song 2");
                DisplaySongOption(3, "Song 3");

                // Prompt user to choose a song option 
                Console.WriteLine(" ");
                Console.Write("Choose between (1) and (3) or (0) to Exit: ");
                int songChoice;

                // Validate user input to prevent exceptions
                if (!int.TryParse(Console.ReadLine(), out songChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 3.");
                    continue;
                }

                // Allows user to exit if they do not want to play any songs 
                if (songChoice == 0)
                {
                    System.Environment.Exit(0);
                }

                Console.WriteLine(" ");

                // Switch statement to handle the selected song option
                // Marks the selected song as played 
                switch (songChoice)
                {
                    case 1:
                        PlaySongOne();
                        songsPlayed[0] = true; // Marks song one as played
                        break;
                    case 2:
                        PlaySongTwo();
                        songsPlayed[1] = true; // Marks song two as played
                        break;
                    case 3:
                        PlaySongThree();
                        songsPlayed[2] = true; // Marks song three as played
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 3.");
                        break;
                }

                Console.WriteLine(" ");
            }
        }

        // Displays a song option, turning text green if the song has been played 
        private void DisplaySongOption(int songNumber, string songName)
        {
            // Checks if the song has been played by looking at the index in the songsPlayed array
            if (songsPlayed[songNumber - 1])
            {
                Console.ForegroundColor = ConsoleColor.Green; // Changes text color to green if the song has been played 
            }
            Console.WriteLine($"{songNumber}. {songName}"); // Displays menu with song name and number 
            Console.ResetColor(); // Resets the console text color back to default after displaying the song option
        }

        // Plays the first song and checks if the file exists 
        public void PlaySongOne()
        {
            PlaySong("30208__guitarz1970__heavy-e7-e79.wav");
        }

        // Plays the second song and checks if the file exists 
        public void PlaySongTwo()
        {
            PlaySong("275301__slivkro__dubstepbeatprocessedpro90.wav");
        }

        // Plays the third song and checks if the file exists 
        public void PlaySongThree()
        {
            PlaySong("276576__serylis__guitar-party-122-bpm.wav");
        }

        // Generic method to play a song given the filename
        private void PlaySong(string fileName)
        {
            Console.WriteLine("~ P L A Y I N G  S O N G ~ ");

            // Construct the full path to the audio file
            string musicFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Music", fileName);

            if (File.Exists(musicFilePath))
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"File found at: {musicFilePath}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                SoundPlayer player = new SoundPlayer(musicFilePath); // SoundPlayer is used to play the song 
                player.PlaySync(); // PlaySync() waits for the song to finish before continuing
            }
            else
            {
                Console.WriteLine($"File not found: {musicFilePath}");
            }

            Console.WriteLine("\n--Press any key to return to the menu or (0) to quit--"); // Waits for user input before returning to menu
            string quitInput = Console.ReadLine();
            if (quitInput == "0") // Checks if user entered 0 to quit 
            {
                System.Environment.Exit(0);
            }
        }
    }

}