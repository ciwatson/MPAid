using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPAid.Modules
{
    public class Serializer<T>
    where T : class, ISerializable, new()
    {
        static public String Serialize<F>(T t) where F : IFormatter, new()
        {
            String result = "";
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    IFormatter ser = new F();
                    ser.Serialize(stream, t);
                    result = Encoding.Unicode.GetString(stream.GetBuffer());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        static public T Deserialize<F>(String s) where F : IFormatter, new()
        {
            T t = new T();
            try
            {
                if(s != String.Empty)
                {
                    using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(s)))
                    {
                        IFormatter ser = new F();
                        t = ser.Deserialize(stream) as T;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return t;
        }

        static public void Save<F>(string path, T t) where F : IFormatter, new()
        {
            try
            {              
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        string content = Serialize<F>(t);
                        sw.Write(content);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public T Load<F>(string path) where F : IFormatter, new()
        {
            T t = null;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string content = sr.ReadToEnd();
                        t = Deserialize<F>(content) as T;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return t;
        }
    }
}
