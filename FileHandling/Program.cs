// Console.WriteLine("========== Employee Records ==========");


// using StreamReader reader = new StreamReader("Employees.txt");

// List<string[]> invalidEnteries = new();

// decimal salary = 0;

// string? line;

// Console.WriteLine("Valid enteries");
// while ((line = reader.ReadLine()) != null)
// {
//     string[] employeedata = line.Split(",", StringSplitOptions.TrimEntries);
//     if (employeedata.Length != 4)
//     {
//         invalidEnteries.Add(employeedata);
//     }
//     else
//     {
//          if(!decimal.TryParse(employeedata[3],out decimal sal))
//         {
//             invalidEnteries.Add(employeedata);

//         }
//         else
//         {
//             Console.WriteLine($"id =  {employeedata[0]} | name = {employeedata[1]} role = {employeedata[2]} salary = {employeedata[3]}");
//             salary += sal;
//         }
//     }

// }

// Console.WriteLine($"\n invalid record");
// foreach (var item in invalidEnteries)
// {
//     foreach (var entry in item)
//     {
//         Console.Write(entry + " ");
//     }

//     Console.WriteLine();

// }
// Console.WriteLine($"\nvalid total salary  : {salary}");


// using StreamWriter write = new("Employees.txt" , append : true);

// write.WriteLine("107, akash , support , 56000");


// string folderPath = "Data";

// Directory.CreateDirectory(folderPath);

// string filename = "hello.txt";

// string fullpath = Path.Combine(folderPath , filename);

// using StreamWriter writer = new(fullpath);  

// writer.WriteLine("hello from txt");



// try
// {
//     using StreamReader reader = new("xyz.txt");

//     string data = reader.ReadToEnd();

//     Console.WriteLine(data);
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Something went wrong: {ex.Message}");
// 



using CsvHelper;

try
{

    using var csv = CsvReader.FromFile("Employees.txt", CsvReaderOptions.Default, FileOptions.None);
    int totalEmployees = 0;
    decimal totalsalary = 0;

    Console.WriteLine("========== ALL EMPLOYEES ==========");
    
    var Employees = csv.GetRecords<Employee>().ToList();

    List<string> developers = new List<string>();

    foreach (var item in Employees)
    {
        
        Console.WriteLine($"ID : {item.Id} | Name :{item.Name} | Role : {item.Role} | Salary : {item.Salary}");
        totalEmployees++;
        totalsalary += item.Salary;
        if(item.Role == "Developer")
        {
            developers.Add(item.Name);
        }
    }

    foreach (var dev in developers)
    {
        Console.WriteLine(dev);
    }

}
catch (Exception ex)
{
    Console.WriteLine($"unexpected error accor error message  : {ex}");
}

[CsvRecord]
public partial class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}