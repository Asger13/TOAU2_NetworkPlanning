using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TOAU1_Simplecs
{
    public class Serialize
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
        public List<Product> DeserializeObject(string filename)
        {
            List<Product> me;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                me = (List<Product>)formatter.Deserialize(fs);
            }
            return me;
        }
        public void SerializeObject(string filename, List<Product> me)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            formatter.Serialize(fs, me);
            fs.Close();
        }
    }
}
