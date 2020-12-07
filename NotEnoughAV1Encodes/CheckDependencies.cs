﻿using System;
using System.IO;

namespace NotEnoughAV1Encodes
{
    class CheckDependencies
    {
        public static void Check()
        {
            // Sets / Checks ffmpeg Path
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg.exe"))) { MainWindow.FFmpegPath = Directory.GetCurrentDirectory(); }
            else if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Apps", "ffmpeg", "ffmpeg.exe"))) { MainWindow.FFmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "Apps", "ffmpeg"); }
            else if (ExistsOnPath("ffmpeg.exe")) { MainWindow.FFmpegPath = GetFullPathWithOutName("ffmpeg.exe"); }
            else { MainWindow.FFmpegPath = null; }
            SmallFunctions.Logging("FFmpeg Path: " + MainWindow.FFmpegPath);

            // Sets / Checks aomenc Path
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "aomenc.exe"))) { MainWindow.AomencPath = Directory.GetCurrentDirectory(); }
            else if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Apps", "aomenc", "aomenc.exe"))) { MainWindow.AomencPath = Path.Combine(Directory.GetCurrentDirectory(), "Apps", "aomenc"); }
            else if (ExistsOnPath("aomenc.exe")) { MainWindow.AomencPath = GetFullPathWithOutName("aomenc.exe"); }
            else { MainWindow.AomencPath = null; }
            SmallFunctions.Logging("Aomenc Path: " + MainWindow.AomencPath);

            // Sets / Checks rav1e Path
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "rav1e.exe"))) { MainWindow.Rav1ePath = Directory.GetCurrentDirectory(); }
            else if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Apps", "rav1e", "rav1e.exe"))) { MainWindow.Rav1ePath = Path.Combine(Directory.GetCurrentDirectory(), "Apps", "rav1e"); }
            else if (ExistsOnPath("rav1e.exe")) { MainWindow.Rav1ePath = GetFullPathWithOutName("rav1e.exe"); }
            else { MainWindow.Rav1ePath = null; }
            SmallFunctions.Logging("Rav1e Path: " + MainWindow.Rav1ePath);

            // Sets / Checks svt-av1 Path
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "SvtAv1EncApp.exe"))) { MainWindow.SvtAV1Path = Directory.GetCurrentDirectory(); }
            else if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Apps", "svt-av1", "SvtAv1EncApp.exe"))) { MainWindow.SvtAV1Path = Path.Combine(Directory.GetCurrentDirectory(), "Apps", "svt-av1"); }
            else if (ExistsOnPath("SvtAv1EncApp.exe")) { MainWindow.SvtAV1Path = GetFullPathWithOutName("SvtAv1EncApp.exe"); }
            else { MainWindow.SvtAV1Path = null; }
            SmallFunctions.Logging("SVT-AV1 Path: " + MainWindow.SvtAV1Path);

            // Sets / Checks mkvtoolnix Path
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "mkvmerge.exe"))) { MainWindow.MKVToolNixPath = Directory.GetCurrentDirectory(); }
            else if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Apps", "mkvtoolnix", "mkvmerge.exe"))) { MainWindow.MKVToolNixPath = Path.Combine(Directory.GetCurrentDirectory(), "Apps", "mkvtoolnix"); }
            else if (ExistsOnPath("mkvmerge.exe")) { MainWindow.MKVToolNixPath = GetFullPathWithOutName("mkvmerge.exe"); }
            else if (File.Exists(@"C:\Program Files\MKVToolNix\mkvmerge.exe")) { MainWindow.MKVToolNixPath = @"C:\Program Files\MKVToolNix\"; }
            else { MainWindow.MKVToolNixPath = null; }
            SmallFunctions.Logging("MKVToolNix Path: " + MainWindow.MKVToolNixPath);
        }

        private static bool ExistsOnPath(string fileName)
        {
            // Checks if file exists in PATH Environment
            return GetFullPath(fileName) != null;
        }

        private static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        private static string GetFullPathWithOutName(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return path; // Returns the PATH without Filename
            }
            return null;
        }
    }
}