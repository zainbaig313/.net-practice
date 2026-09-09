
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Project
{
    public class Person
    {
        required public string UserName{ get; set;}
        public int UserAge {get; set;}
    }
    static void Main()
    {
        Person samplePerson = new Person
        {
          UserName = "zain baig",
          UserAge =23  
        };



        using(FileStream fs = new FileStream("zain.dat" , FileMode.Create))
        using(BinaryWriter bs = new BinaryWriter(fs))
        {
            bs.Write(samplePerson.UserName);
            bs.Write(samplePerson.UserAge);
        }

        Console.WriteLine("binary write ho gya hai");



        XmlSerializer xs= new XmlSerializer(typeof(Person));
        using(StreamWriter sw = new StreamWriter("zain.xml"))
        {
            xs.Serialize(sw , samplePerson);
        }

        Console.WriteLine("xml ho gya");


        string jsonString = JsonSerializer.Serialize(samplePerson);
        File.WriteAllText("zain.json" , jsonString);
        
        Console.WriteLine("json ho gya");;


        using(FileStream fs = new FileStream("zain.dat" , FileMode.Open))
        using(BinaryReader bs = new BinaryReader(fs))
        {
            Person dPerson = new Person
            {
                UserName = bs.ReadString(),
                UserAge = bs.ReadInt32()
            };

            Console.WriteLine($"descerilied name or age han  {dPerson.UserName} and {dPerson.UserAge}");
        }



        XmlSerializer dxml =  new XmlSerializer(typeof(Person));
        using(StreamReader ds = new StreamReader("zain.xml"))
        {
            Person dxmlPerson = (Person)dxml.Deserialize(ds);

            Console.WriteLine($"dxml name{dxmlPerson.UserName} and age ios {dxmlPerson.UserAge}");
        }

        string dJsonString = File.ReadAllText("zain.json");
        Person djson = JsonSerializer.Deserialize<Person>(dJsonString);

        Console.WriteLine($"json name{djson.UserName} and age ios {djson.UserAge}");


    }


    
}