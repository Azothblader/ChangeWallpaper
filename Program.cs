using Microsoft.Win32;
using System;

namespace ChangeWallpaper_RE
{
    class Program
    {
        static  string WallpaerStyle = "2";
        static string WallpaperPath = "";
        static string WallpaperBackup = "";
        static void ShowCurrentSts(ref RegistryKey Policykey)
        {
            if (Policykey != null)
            {
                WallpaerStyle = Policykey.GetValue("WallpaperStyle").ToString();
                WallpaperPath = Policykey.GetValue("Wallpaper").ToString();
                WallpaperBackup = Policykey.GetValue("Wallpaper_backup").ToString();

            }
            
            Console.WriteLine("======================================   ");
            Console.WriteLine("Hello there !");
            Console.WriteLine("Current Policy Wallpaper : " + WallpaperPath);
            Console.WriteLine("BackUp Policy Wallpaper : " + WallpaperBackup);
            Console.WriteLine("WallpaerStyle : " + WallpaerStyle);

            Console.WriteLine(" > Choose Operation Mode ");

        }

        static void Main(string[] args)
        {
            Console.WriteLine(" ChangeWallpaper Regedit v1.0 ");
            string RootPolicyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
            RegistryKey Policykey = Registry.CurrentUser.OpenSubKey(RootPolicyPath,true); 

            bool doOp = true;
            while (doOp) {
                ShowCurrentSts(ref Policykey);

              
                Console.WriteLine(" > S - Set Wallpaper Style ");
                Console.WriteLine(" > C - Set Current Wallpaper Path ");
                Console.WriteLine(" > B - Set BackUp Wallpaper Path ");
                Console.WriteLine(" > other chars - Quit ");
                var t = Console.ReadKey();
                if (t.KeyChar.ToString().ToUpper() == "S")
                {
                    Console.WriteLine(" >> Insert Value (0/1/2)");
                    var s= Console.ReadKey();
                    Policykey.SetValue("WallpaperStyle", s.KeyChar.ToString());
                    Console.WriteLine("");
                }
                else if (t.KeyChar.ToString().ToUpper() == "C")
                {
                    Console.WriteLine(" >> Insert path of New Wallpaper ");
                    var s = Console.ReadLine();
                    Policykey.SetValue("Wallpaper", s.ToString());
                }
                else if (t.KeyChar.ToString().ToUpper() == "B")
                {
                    Console.WriteLine(" >> Insert Path for BackUp");
                    var s = Console.ReadLine();
                    Policykey.SetValue("Wallpaper_backup", s.ToString());

                }
                else {

                    Console.WriteLine(" >>> Exit ? press Y ");
                     var te = Console.ReadKey();
                    if (te.KeyChar.ToString().ToUpper() == "Y") {
                        Policykey.Close(); 
                        doOp = false;
                    }
                    else {
                        doOp = true;
                    }
                }

            }

            System.Environment.Exit(0);
        }
    }
}
