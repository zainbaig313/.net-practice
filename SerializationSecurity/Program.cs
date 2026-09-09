

using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class Project
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string password {get; set;}

        public string GenerateHash()
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(ToString()));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public void EncodePassword()
        {
            password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
    }

    public static string SerializedUserData(User user)
    {
        if( string.IsNullOrWhiteSpace(user.Name)
            || string.IsNullOrWhiteSpace(user.Email)
            || string.IsNullOrWhiteSpace(user.password)

        )
        {
            Console.WriteLine("invliad data  : serilization abort");
            return string.Empty;
        }

        user.EncodePassword();
        return JsonSerializer.Serialize(user);
    }

    public static  User DeserializedUserData(string jsonStrign , bool isTrustedSource)
    {
        if (isTrustedSource)
        {
            return JsonSerializer.Deserialize<User>(jsonStrign);
        }
        Console.WriteLine("not form trusted source fail");
        return null;
    }
    static void Main()
    {
        User user = new User
        {
            Name= "Zainbaig ",
             Email = "hell@23",
             password =  "wpw122"
        };

        string generateHash   = user.GenerateHash();
        string serializedUserdata = SerializedUserData(user);
        User deserializedUserData = DeserializedUserData(serializedUserdata ,  false);

        Console.WriteLine("genmretred hash :\n"+ generateHash);
        Console.WriteLine("serilized data : " + serializedUserdata);
        Console.WriteLine(deserializedUserData);
    }
}