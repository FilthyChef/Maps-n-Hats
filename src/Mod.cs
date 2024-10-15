using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

// The title of your mod, as displayed in menus.
[assembly: AssemblyTitle("Maps'n'Hats Modpack Template")]
//This will be the name of folders created in `DuckGame\Levels\Level Modpacks` & `DuckGame\Hats\Hat Modpacks`.
[assembly: AssemblyCompany("Artist")]
// The description of the mod.
[assembly: AssemblyDescription("My maps, hats, and all the rest of custom content with their cataloging structures.")]
// The mod's version.
[assembly: AssemblyVersion("1.0.0.0")]

//Rename all occurrences of the "MapsHatsTemplate" in document, according to your mod's name, no spaces or symbols (Ctrl+H for most text editors).
namespace DuckGame.MapsHatsTemplateModpack{
    public class MapsHatsTemplate : Mod
    {
        // This function is run before all mods are finished loading.
        protected override void OnPreInitialize(){
            CopyContent();
            base.OnPreInitialize();
        }
        protected override void OnPostInitialize(){
            base.OnPostInitialize();
        }
        private byte[] GetMD5Hash(byte[] sourceBytes) {
            return new MD5CryptoServiceProvider().ComputeHash(sourceBytes);
        }
        private void CopyContent(){

			string FolderName = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;

            var OldLevelsLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Levels"));
            string NewLevelsLocation = Path.Combine(DuckFile.levelDirectory + "Level Modpacks/", FolderName);
            foreach(var f in OldLevelsLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Levels");
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newl = NewLevelsLocation + "/" + relativePath;  //*Should* be using Path.Combine here but was having problems for some reason
                Directory.CreateDirectory(Path.GetDirectoryName(newl));
                if (!File.Exists(newl) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newl))))
                {
                    f.CopyTo(newl, true);
                }
            }

			var OldHatsLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Hats"));
            string NewHatsLocation = DuckFile.saveDirectory + "Custom/Hats/"; //DG only checks the top-level Hats folder
            foreach (var f in OldHatsLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Hats");
                string relativePath = Path.GetFileName(f.FullName); //Flatten the directory structure because DG won't look beyond the top-level folder for Hats
                string newh = NewHatsLocation + "/" + relativePath;
                Directory.CreateDirectory(Path.GetDirectoryName(newh));
                if (!File.Exists(newh) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newh))))
                {
                    f.CopyTo(newh, true);
                }
            }

			var OldMojisLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Mojis"));
            string NewMojisLocation = DuckFile.customMojiDirectory; //Like hats, DG only checks the top-level folder here :(
            foreach (var f in OldMojisLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Mojis");
                string relativePath = Path.GetFileName(f.FullName); //Flatten the directory structure because DG won't look beyond the top-level folder for Mojis
                string newm = NewMojisLocation + "/" + relativePath;
                Directory.CreateDirectory(Path.GetDirectoryName(newm));
                if (!File.Exists(newm) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newm))))
                {
                    f.CopyTo(newm, true);
                }
            }

			var OldArcadeLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Arcade"));
            string NewArcadeLocation = Path.Combine(DuckFile.customArcadeDirectory, FolderName); //I don't know if this is even still used
            foreach (var f in OldArcadeLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Arcade");
                //Not using Path.GetRelativePath here because the version of .NET used doesn't support it :(
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newarc = NewArcadeLocation + "/" + relativePath;
                Directory.CreateDirectory(Path.GetDirectoryName(newarc));
                if (!File.Exists(newarc) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newarc))))
                {
                    f.CopyTo(newarc, true);
                }
            }

			var OldBGLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Background"));
            string NewBGLocation = Path.Combine(DuckFile.customBackgroundDirectory, FolderName);
            foreach (var f in OldBGLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Background");
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newbg = NewBGLocation + "/" + relativePath;
                Directory.CreateDirectory(Path.GetDirectoryName(newbg));
                if (!File.Exists(newbg) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newbg))))
                {
                    f.CopyTo(newbg, true);
                }
            }

			var OldBlocksLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Blocks"));
            string NewBlocksLocation = Path.Combine(DuckFile.customBlockDirectory, FolderName);
            foreach (var f in OldBlocksLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Blocks");
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newbck = NewBlocksLocation + "/" + relativePath;
                Directory.CreateDirectory(Path.GetDirectoryName(newbck));
                if (!File.Exists(newbck) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newbck))))
                {
                    f.CopyTo(newbck, true);
                }
            }

			var OldParallaxLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Parallax"));
            string NewParallaxLocation = Path.Combine(DuckFile.customParallaxDirectory, FolderName);
            foreach (var f in OldParallaxLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Parallax");
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newplx = NewParallaxLocation + "/" + relativePath;
                Directory.CreateDirectory( Path.GetDirectoryName( newplx ) );
                if (!File.Exists(newplx) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newplx))))
                {
                    f.CopyTo(newplx, true);
                }
            }

			var OldPlatformLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Platform"));
            string NewPlatformLocation = Path.Combine(DuckFile.customPlatformDirectory, FolderName);
            foreach (var f in OldPlatformLocation.GetFiles("*", SearchOption.AllDirectories))
            {
				string oldDir = GetPath<MapsHatsTemplate>("Platform");
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newplatfus = NewPlatformLocation + "/" + relativePath; 
                Directory.CreateDirectory( Path.GetDirectoryName(newplatfus) );
                if (!File.Exists(newplatfus) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newplatfus))))
                {
                    f.CopyTo(newplatfus, true);
                }
            }

			var OldReTexturesLocation = new DirectoryInfo(GetPath<MapsHatsTemplate>("Texpacks"));
            string NewReTextureLocation = Path.Combine(DuckFile.globalSkinsDirectory, FolderName + "'s Texture Pack");
            foreach (var f in OldReTexturesLocation.GetFiles("*", SearchOption.AllDirectories))
            {
                string oldDir = GetPath<MapsHatsTemplate>("Texpacks");
                string relativePath = f.FullName.Substring(f.FullName.LastIndexOf(oldDir) + oldDir.Length + 1);
                string newrtx = NewReTextureLocation + "/" + relativePath;
                Directory.CreateDirectory(Path.GetDirectoryName(newrtx));
                if (!File.Exists(newrtx) || !GetMD5Hash(File.ReadAllBytes(f.FullName)).SequenceEqual(GetMD5Hash(File.ReadAllBytes(newrtx))))
                {
                    f.CopyTo(newrtx, true);
                }
            }
		}
    }
}