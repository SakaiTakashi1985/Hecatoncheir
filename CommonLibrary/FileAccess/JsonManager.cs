using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using static System.Console;
using System.Runtime.CompilerServices;
using Codeplex.Data;

namespace CommonLibrary.FileAccess
{
    public class JsonManager
    {
        public static T ReadJson<T>(string path) where T : new()
        {
            T retDic = new T();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    var settings = new DataContractJsonSerializerSettings();
                    //settings.UseSimpleDictionaryFormat = true;
                    var serializer = new DataContractJsonSerializer(typeof(T), settings);
                    retDic = (T)serializer.ReadObject(sr.BaseStream);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            catch (FileNotFoundException)
            {
            }

            return retDic;
        }

        public static void WriteJson<T>(string path, T data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(DynamicJson.Serialize(data));
            }
        }
    }
}
