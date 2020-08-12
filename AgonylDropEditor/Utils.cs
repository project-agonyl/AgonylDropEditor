using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgonylDropEditor
{
    public static class Utils
    {
        public static Dictionary<uint, Monster> MonsterList { get; private set; }

        public static Dictionary<ushort, Item> ItemList { get; private set; }

        public static void LoadMonsterData()
        {
            var file = GetMyDirectory() + Path.DirectorySeparatorChar + "MON.txt";
            var monsterDataFile = File.ReadAllText(file);
            var data = monsterDataFile.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            MonsterList = new Dictionary<uint, Monster>();
            for (var i = 1; i < Convert.ToInt32(data[0].Trim(';').Split('=')[1]); i++)
            {
                var currentLine = data[i].Split(',');
                if (currentLine.Length < 2)
                {
                    continue;
                }

                var id = Convert.ToUInt32(currentLine[0]);
                if (MonsterList.ContainsKey(id))
                {
                    continue;
                }

                var item = new Monster()
                {
                    Id = id,
                    Name = currentLine[1].Trim(),
                };
                MonsterList.Add(item.Id, item);
            }
        }

        public static void LoadItemData()
        {
            ItemList = new Dictionary<ushort, Item>();
            LoadIT0File();
            LoadIT1File();
            LoadIT2File();
            LoadIT3File();
        }

        public static void LoadIT0File()
        {
            var it0File = GetMyDirectory() + Path.DirectorySeparatorChar + "IT0.txt";
            var it0FileData = File.ReadAllText(it0File);
            var data = it0FileData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (var i = 1; i < data.Length; i++)
            {
                var currentLine = data[i].Split(',');
                if (currentLine.Length < 6 || !ushort.TryParse(currentLine[0], out _))
                {
                    continue;
                }

                var id = Convert.ToUInt16(currentLine[0]);
                if (ItemList.ContainsKey(id))
                {
                    continue;
                }

                var item = new Item()
                {
                    Id = id,
                    Name = currentLine[5].Trim(),
                };
                ItemList.Add(item.Id, item);
            }
        }

        public static void LoadIT1File()
        {
            var it1File = GetMyDirectory() + Path.DirectorySeparatorChar + "IT1.txt";
            var it1FileData = File.ReadAllText(it1File);
            var data = it1FileData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (var i = 1; i < Convert.ToInt32(data[0].Trim(';').Split('=')[1]); i++)
            {
                var currentLine = data[i].Split(',');
                if (currentLine.Length < 4)
                {
                    continue;
                }

                var id = Convert.ToUInt16(currentLine[0]);
                if (ItemList.ContainsKey(id))
                {
                    continue;
                }

                var item = new Item()
                {
                    Id = id,
                    Name = currentLine[3].Trim(),
                };
                ItemList.Add(item.Id, item);
            }
        }

        public static void LoadIT2File()
        {
            var it2File = GetMyDirectory() + Path.DirectorySeparatorChar + "IT2.txt";
            var it2FileData = File.ReadAllText(it2File);
            var data = it2FileData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (var i = 1; i < Convert.ToInt32(data[0].Trim(';').Split('=')[1]); i++)
            {
                var currentLine = data[i].Split(',');
                if (currentLine.Length < 4)
                {
                    continue;
                }

                var id = Convert.ToUInt16(currentLine[0]);
                if (ItemList.ContainsKey(id))
                {
                    continue;
                }

                var item = new Item()
                {
                    Id = id,
                    Name = currentLine[3].Trim(),
                };
                ItemList.Add(item.Id, item);
            }
        }

        public static void LoadIT3File()
        {
            var it3File = GetMyDirectory() + Path.DirectorySeparatorChar + "IT3.txt";
            var it3FileData = File.ReadAllText(it3File);
            var data = it3FileData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (var i = 1; i < Convert.ToInt32(data[0].Trim(';').Split('=')[1]); i++)
            {
                var currentLine = data[i].Split(',');
                if (currentLine.Length < 4)
                {
                    continue;
                }

                var id = Convert.ToUInt16(currentLine[0]);
                if (ItemList.ContainsKey(id))
                {
                    continue;
                }

                var item = new Item()
                {
                    Id = id,
                    Name = currentLine[3].Trim(),
                };
                ItemList.Add(item.Id, item);
            }
        }

        public static string GetMyDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        public static byte[] SkipAndTakeLinqShim(ref byte[] originalBytes, int take, int skip = 0)
        {
            if (skip + take > originalBytes.Length)
            {
                return new byte[] { };
            }

            var outByte = new byte[take];
            Array.Copy(originalBytes, skip, outByte, 0, take);
            return outByte;
        }

        public static ushort BytesToUInt16(byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes, 0);
        }
    }
}
