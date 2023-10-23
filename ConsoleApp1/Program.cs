
using Plugin.SimpleAudioPlayer;
using System;
using System.Drawing.Printing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    static void typewrite(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Console.Beep(500, 60);

            Thread.Sleep(50);
        }
        Console.WriteLine();

    }
    static void centerText(string text) {
        Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);

    }
    static void start()
       
    {
        Console.Title = "Number guesser by Kareem";
        Console.ForegroundColor = ConsoleColor.Magenta;
        string author = "author :Kareem Ayman";
        string gameVersion = " game version :1.0.0";
        string gameName = "number guesser game";

        centerText(author);
        typewrite(author);
        Thread.Sleep(1000);
        centerText(gameVersion);
        typewrite(gameVersion);
        Thread.Sleep(1000);
        centerText(gameName);
        typewrite(gameName);
        string chooseLevel = "choose your level:\n [1] 0-10\n [2] 0-20\n [3] 0-50\n [4] 0-100\n [ninja] 0-1000";
        PlayBgMusicAsync();
        typewrite(chooseLevel);
        chooseYourLevel();
    }
    static void generateStart() {
        string author = "author :Kareem";
        string gameVersion = " game version :1.0.0";
        string gameName = "number guesser game";
        Console.Clear();
        centerText(author);
        Console.WriteLine(author);
        centerText(gameVersion);
        Console.WriteLine(gameVersion);
        centerText(gameName);
        Console.WriteLine(gameName);
        string chooseLevel = "choose your level:\n [1] 0-10\n [2] 0-20\n [3] 0-50\n [4] 0-100\n [ninja] 0-1000";
        PlayBgMusicAsync();
        typewrite(chooseLevel);
        chooseYourLevel();


    }
    static bool firstRun= true;
    static async Task PlayBgMusicAsync()
    {
        if (OperatingSystem.IsWindows())
        {
            
            Task.Run(() => { 
            if (firstRun) {
                    SoundPlayer soundplayer = new SoundPlayer("MortalKombatFight.wav");
                    
                    soundplayer.Play();
                    Thread.Sleep(2500);
                    soundplayer.Dispose();
                    firstRun = false;
                }
            SoundPlayer bg = new SoundPlayer("bg1.wav");
            bg.PlayLooping(); 
            
            });

            
        }
    }
    
    static void  guess(int number) {
        Random rand = new Random();
        int target =0;
        int max = 10;
        switch (number)
        {
            case 1: { 
               target = rand.Next(0,10);
                    max = 10;
                }break;
            case 2: {
                    target = rand.Next(0,20);
                    max = 20;
                
                } break; 
            case 3: {
                    target = rand.Next(0,50);
                    max = 50;
                
                } break;
            case 4: {
                    target = rand.Next(0,100);
                    max = 100;
                
                } break;
            case 5: {
                    target = rand.Next(0,1000);
                    max = 1000;
                
                } break;
        }

        takeGuess(number,target,max);
        
        }
    static void takeGuess(int number,int rand,int max) {
        Console.WriteLine("take your guess hero!:");
        // take an input and check if either it's right or wrong or wrong input
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            wrongInput();
            PlayBgMusicAsync();
            guess(number);

        }
        else
        {
            if (num > max|| num<0)
            {
                wrongInput();
                Console.WriteLine("outside the level range");
                PlayBgMusicAsync();
                takeGuess(number, rand, max);
            }
            else {
                if (rand.Equals(num))
                {
                    success();
                    playAgain();
                }
                else
                {
                    //fail();
                    if (rand > num)
                    {
                        Console.WriteLine("go higher");
                    }
                    else
                    {
                        Console.WriteLine("go lower");
                    }
                    takeGuess(number, rand, max);
                }
            }
        }
    }
    static void fail()
    {
        SoundPlayer soundplayer = new SoundPlayer("fail.wav");
        soundplayer.Play();
        Console.WriteLine("not there yet");

    }
    static void playAgain()
    {
        Console.WriteLine("wanna play again?\n [y]yes ,[n]no");
        string input = Console.ReadLine().ToLower();
        switch (input)
        {
            case "y":
                generateStart();
                break;
            case "n":
                Console.Write("thank you for playing");
                Console.ForegroundColor = ConsoleColor.Red;
                goodbye();
                Thread.Sleep(2000);
                break;
            default:
                Console.Write("thank you for playing");
                Console.ForegroundColor = ConsoleColor.Red;
                goodbye();
                Thread.Sleep(2000);
                
                break;

        }
    }
    static void goodbye() {
        SoundPlayer soundplayer = new SoundPlayer("bye.wav");
        soundplayer.Play();
    }
    static void success() {
        SoundPlayer soundplayer = new SoundPlayer("success.wav");
        soundplayer.Play();
        Console.WriteLine("finaaaally ,good job");
    }
    static void chooseYourLevel() {

          string answer = Console.ReadLine().ToLower();
        switch (answer)
        {
            case "1":
                guess(1);
                break;
            case "2":
                guess(2);
                break;
            case "3":
                guess(3);
                break;

            case "4":
                guess(4);
                break;

            case "ninja":
                guess(5);
                break;
            default:
                wrongInput();
                generateStart();
                break;
        }


        }
    static int mistakeCounter = 0;
    static void wrongInput() {
        string[] audio = { "wrongInput.wav", "wrongInput1.wav", "wrongInput2.wav", "wrongInput3.wav" };
        if (mistakeCounter== audio.Length) {
            mistakeCounter = 0;
        }
        
        SoundPlayer soundplayer = new SoundPlayer(audio[mistakeCounter]);
        soundplayer.Play();
        Console.WriteLine("Wrong input press any key to try again");
        Console.ReadKey();
        mistakeCounter++;
        

    }
        static void Main(string[] args)
        {
        
            start();
            
           
           

        
    } }