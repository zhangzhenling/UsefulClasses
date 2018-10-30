using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializer {

    /// <summary>
    ///将类型序列化为字符串
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string Serialize<T> (T t) {
        using (MemoryStream stream = new MemoryStream ()) {
            BinaryFormatter formatter = new BinaryFormatter ();
            formatter.Serialize (stream, t);
            return System.Text.Encoding.UTF8.GetString (stream.ToArray ());
        }
    }

    /// <summary>
    /// 将类型序列化为文件
    /// </summary>
    /// <param name="t"></param>
    /// <param name="path"></param>
    /// <param name="fullName"></param>
    /// <typeparam name="T"></typeparam>
    public static void SerializeToFile<T> (T t, string path, string fullName) {
        if (!Directory.Exists (Path)) {
            Directory.CreateDirectory (path);
        }
        string fullPath = Path.Combine (path, fullName);
        using (FileStream stream = new FileStream (fullPath, FileMode.OpenOrCreate)) {
            BinaryFormatter formatter = new BinaryFormatter ();
            formatter.Serialize (stream, t);
            stream.Flush ();
        }
    }
    /// <summary>
    /// 将字符串反序列化为类型
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public static TResult Deserialize<TResult> (string s) where TResult : class {
        byte[] bs = System.Text.Encoding.UTF8.GetBytes (s);
        using (MemoryStream stream = new MemboryStream (bs)) {
            BinaryFormatter formatter = new BinaryFormatter ();
            return formatter.Deserialize (stream) as TResult;
        }
    }

    /// <summary>
    /// 将文件反序列化为类型
    /// </summary>
    /// <param name="path"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static TResult DeserializeFromFile<TResult> (string path) where TResult : class {
        using (FileStream stream = new FileStream(path,FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream) as TResult;
        }
    }
}